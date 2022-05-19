using Business.Abstract;
using Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Login(UserLoginRequest userLoginRequest)
        {
            var result = _userService.ValidateUser(userLoginRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
