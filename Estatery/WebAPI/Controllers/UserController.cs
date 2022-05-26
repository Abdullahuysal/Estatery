using Business.Abstract;
using Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MimeKit;

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
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var result = await _userService.ValidateUser(userLoginRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Signup(UserSignupRequest userSignupRequest)
        {
            var result = await _userService.SignupUser(userSignupRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getuserInfo")]
        public async Task<IActionResult> GetUserInfo(int id)
        {
            var result = await _userService.GetUserById(id);
            if (result.Success == true)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserEmail")]
        public async Task<IActionResult> GetUserEmail(string username)
        {
            var result = await _userService.GetUserEmail(username);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("updateuser")]
        public async Task<IActionResult> Updateuser(UserUpdateRequest userUpdateRequest)
        {
            var result = await _userService.UpdateUser(userUpdateRequest);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("deleteuser")]
        public async Task<IActionResult> DeleteUser(int Userid)
        {
            var result = await _userService.DeleteUser(Userid);
            if (result.Success == true)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
