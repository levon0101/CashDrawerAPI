using System.Collections.Generic;
using AutoMapper;
using CashDrawerAPI.Repositories;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Models;

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

        [HttpGet("{id}", Name = "GetWalletById")]
        public ActionResult<WalletDto> GetWalletById(long id)
        {

            var walletFromRepo = _walletRepository.GetWalletById(id);

            if (walletFromRepo == null) return NotFound();

            return Ok(_mapper.Map<WalletDto>(walletFromRepo));
        }

        [HttpPost]
        public IActionResult CreateWallet([FromBody] WalletDto wallet)
        {
            var walletEntity = _mapper.Map<Wallet>(wallet);

            if (!TryValidateModel(walletEntity))
            {
                return BadRequest();
            }

            _walletRepository.AddWallet(walletEntity);

            var walletToReturn = _mapper.Map<WalletDto>(walletEntity);


            return CreatedAtRoute("GetWalletById", new { id = walletEntity.Id }, walletToReturn);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateWallet(int id, [FromBody] WalletDto wallet)
        {
            var walletFromDb = _walletRepository.GetWalletById(id);

            if (walletFromDb == null) return NotFound();


            walletFromDb.CurrencyCode = wallet.CurrencyCode;
            walletFromDb.CurrencyName = wallet.CurrencyName;
            walletFromDb.Description = wallet.Description;

            if (!TryValidateModel(walletFromDb))
            {
                return BadRequest();
            }

            _walletRepository.SaveChanges();

            var walletToReturn = _mapper.Map<WalletDto>(walletFromDb);

            return CreatedAtRoute("GetWalletById", new { id = walletFromDb.Id }, walletToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveWallet(int id)
        {
            var walletFromDb = _walletRepository.GetWalletById(id);

            if (walletFromDb == null) return NotFound();

            _walletRepository.DeleteWallet(walletFromDb);

            return NoContent();
        }
    }
}
