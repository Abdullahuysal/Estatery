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
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(UserLoginRequest userLoginRequest)
        {

            return Redirect("https://www.youtube.com/");
        }
    }
}
