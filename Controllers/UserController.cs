using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PvDriver.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userRepository.GetAll();
            if(result.IsError())
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
