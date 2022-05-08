using Business.Abstract;
using Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(UserLoginRequest userLoginRequest)
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignupPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignupPage(UserSignupRequest userSignupRequest)
        {
            var result = _userService.SignupUser(userSignupRequest);
            if (result.Result.Success == true)
            {
                return Redirect("/Home/HomePage");
            }
            return View();
        }
    }
}
