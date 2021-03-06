﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CashDrawerAPI.Repositories;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CashDrawerAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserWalletController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserWalletRepository _userWalletRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IEuroRateProvider _euroRateProvider;

        public UserWalletController(IMapper mapper,
            IUserWalletRepository userWalletRepository,
            IUserRepository userRepository,
            IWalletRepository walletRepository,
            IEuroRateProvider euroRateProvider)

        {
            _mapper = mapper;
            _userWalletRepository = userWalletRepository;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _euroRateProvider = euroRateProvider;
        }

        [HttpGet("{userId}/[controller]", Name = "GetUserWallets")]
        public ActionResult<IEnumerable<UserWalletDto>> GetUserWallets(long userId)
        {

            var userWalletFromDb = _userWalletRepository.GetUserWallets(userId);

            if (userWalletFromDb.ToList().Count == 0) return NotFound();

            var userWalletToReturn = _mapper.Map<IEnumerable<UserWalletDto>>(userWalletFromDb);

            return Ok(userWalletToReturn);
        }

        [HttpPost("[controller]")]
        public IActionResult AddWalletToUser([FromBody] UserWalletDto userWallet)
        {
            if (_userRepository.GetUser(userWallet.UserId) == null) return NotFound();

            if (_walletRepository.GetWalletById(userWallet.WalletId) == null) return NotFound();

            var userWalletForCreate = _mapper.Map<UserWallet>(userWallet);

            _userWalletRepository.AddWalletToUser(userWalletForCreate);

            var userWalletToReturn = _mapper.Map<UserWalletDto>(userWalletForCreate);

            return CreatedAtRoute("GetUserWallets", new { userId = userWalletToReturn.UserId }, userWalletToReturn);
        }

        [HttpPost("[controller]/{userWalletId}/FillUp")]
        public IActionResult FillUpWallet(long userWalletId, [FromBody] MoneyDto moneyDto)
        {
            if (moneyDto.Amount <= 0) return BadRequest();

            var userWalletFromDb = _userWalletRepository.GetUserWalletById(userWalletId);

            userWalletFromDb.Balance += moneyDto.Amount;

            _userWalletRepository.SaveChanges();


            var userWalletToReturn = _mapper.Map<UserWalletDto>(userWalletFromDb);

            return CreatedAtRoute("GetUserWallets", new { userId = userWalletToReturn.UserId }, userWalletToReturn);
        }


        [HttpPost("[controller]/{userWalletId}/Withdraw")]
        public IActionResult WithdrawWallet(long userWalletId, [FromBody] MoneyDto moneyDto)
        {
            if (moneyDto.Amount <= 0) return BadRequest();

            var userWalletFromDb = _userWalletRepository.GetUserWalletById(userWalletId);

            userWalletFromDb.Balance -= moneyDto.Amount;

            if (userWalletFromDb.Balance < 0) return BadRequest();

            _userWalletRepository.SaveChanges();


            var userWalletToReturn = _mapper.Map<UserWalletDto>(userWalletFromDb);

            return CreatedAtRoute("GetUserWallets", new { userId = userWalletToReturn.UserId }, userWalletToReturn);
        }

        [HttpPost("[controller]/Transfer")]
        public IActionResult TransferWallet([FromBody] TransferMoneyDto transferMoneyDto)
        {

            if (transferMoneyDto.Amount <= 0) return BadRequest();


            var fromUserWallet = _userWalletRepository.GetUserWalletById(transferMoneyDto.FromUserWalletId);
            if (fromUserWallet == null) return NotFound();

            var toUserWallet = _userWalletRepository.GetUserWalletById(transferMoneyDto.ToUserWalletId);
            if (toUserWallet == null) return NotFound();


            if (fromUserWallet.WalletId == toUserWallet.WalletId)
            {
                fromUserWallet.Balance -= transferMoneyDto.Amount;

                toUserWallet.Balance += transferMoneyDto.Amount;
            }
            else
            {
                fromUserWallet.Balance -= transferMoneyDto.Amount;

                toUserWallet.Balance += _euroRateProvider
                    .ConvertMoney(fromUserWallet.Wallet.CurrencyCode,
                    toUserWallet.Wallet.CurrencyCode,
                    transferMoneyDto.Amount); ;
            }

            if (!TryValidateModel(fromUserWallet))
            {
                return BadRequest();
            }

            _userWalletRepository.SaveChanges();

            return CreatedAtRoute("GetUserWallets", new { userId = fromUserWallet.UserId }, transferMoneyDto);

        }

    }
}
