using System.Collections.Generic;
using AutoMapper;
using CashDrawerAPI.Repositories;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CashDrawerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalletRepository _walletRepository;

        public WalletController(IMapper mapper, IWalletRepository walletRepository)
        {
            _mapper = mapper;
            _walletRepository = walletRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WalletDto>> GetAllWalletTypes()
        {

            var walletsFromRepo = _walletRepository.GetAllWallets();

            return Ok(_mapper.Map<IEnumerable<WalletDto>>(walletsFromRepo));
        }

        [HttpGet("{id}")]
        public ActionResult<WalletDto> GetWalletById(long id)
        {

            var walletFromRepo = _walletRepository.GetWalletById(id);

            return Ok(_mapper.Map<WalletDto>(walletFromRepo));
        }



    }
}
