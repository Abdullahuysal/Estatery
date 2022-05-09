using Business.Abstract;
using Dtos.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> LoginPage(UserLoginRequest userLoginRequest)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser(userLoginRequest);
                if (user.Result.Data != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,user.Result.Data.Email)
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (Url.IsLocalUrl("/Home/HomePage"))
                    {
                        return RedirectToAction("HomePage", "Home");
                    }
                }
                ModelState.AddModelError("LoginPage", "Kullanıcı Adı veya Şifre Hatalıdır");
            }
            
            return View();
        }
        [HttpGet]
        public IActionResult SignupPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignupPage(UserSignupRequest userSignupRequest)
        {
            var result =await _userService.SignupUser(userSignupRequest);
            if (result!=null)
            {
                Redirect("/Home/HomePage");
            }
            return View();
        }
    }
}
