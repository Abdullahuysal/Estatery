using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LandController : Controller
    {
        private ILandService _landService;
        public LandController(ILandService landService)
        {
            _landService = landService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
