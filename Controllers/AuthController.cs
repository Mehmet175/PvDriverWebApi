using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PvDriver.Models;
using PvDriver.Repository.Abstract;
using PvDriver.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace PvDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var result = _userRepository.Get(m => m.UserName == loginModel.UserName && m.Password == loginModel.Password);

                // Kullanıcı bulunamadı
                if (result.IsEmpty())
                {
                    return Unauthorized();
                }
                // Hata oluştu veri tabnına sorarken
                if (result.IsError())
                {
                    return BadRequest(result.Message);
                }

                // Token oluşturuluyor
                var token = JwtUtil.TokenCreate(result.Data);

                return Ok(new LoginResponse()
                {
                    Token = token,
                    User = result.Data,
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("Me")]
        [Authorize]
        public IActionResult Me()
        {
            var jwtInfo = JwtUtil.GetUserInfo(HttpContext.Request);
            var result = _userRepository.Get(m => m.Id == jwtInfo.UserId);
            if (result.IsEmpty())
            {
                return Unauthorized();
            }
            if (result.IsError())
            {
                return BadRequest(result.Message);
            }
            result.Data.DeviceUsers = null;
            return Ok(result.Data);

        }
    }
}
