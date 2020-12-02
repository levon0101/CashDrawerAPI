using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CashDrawerAPI.Repositories;
using DataAccess;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CashDrawerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var usersFromRepo = _userRepository.GetUsers();

            if (usersFromRepo == null) return NotFound();


            return Ok(_mapper.Map<IEnumerable<UserDto>>(usersFromRepo));
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<UserDto> GetUser(long id)
        {
            var userFromDb = _userRepository.GetUser(id);

            if (userFromDb == null) return NotFound();

            return Ok(_mapper.Map<User, UserDto>(userFromDb));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            var userEntity = _mapper.Map<User>(user);

            if (!TryValidateModel(userEntity))
            {
                return BadRequest();
            }

            _userRepository.AddUser(userEntity);

            var userToReturn = _mapper.Map<UserDto>(userEntity);


            return CreatedAtRoute("GetUser", new { id = user.Id }, userToReturn);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto user)
        {
            var userFromDb = _userRepository.GetUser(id);

            if (userFromDb == null) return NotFound();


            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;

            if (!TryValidateModel(userFromDb))
            {
                return BadRequest();
            }

            _userRepository.SaveChanges();

            var userToReturn = _mapper.Map<UserDto>(userFromDb);

            return CreatedAtRoute("GetUser", new { id = id }, userToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            var userFromDb = _userRepository.GetUser(id);

            if (userFromDb == null) return NotFound();

            _userRepository.DeleteUser(userFromDb);

            return NoContent();
        }
    }
}
