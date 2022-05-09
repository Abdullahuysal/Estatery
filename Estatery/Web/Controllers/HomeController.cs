using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHouseService _houseService;
        private ILandService _landService;
        private IWorkPlaceService _workplaceService;
        public HomeController(ILogger<HomeController> logger,IHouseService houseService,ILandService landService,IWorkPlaceService workPlaceService)
        {
            _logger = logger;
            _houseService = houseService;
            _landService = landService;
            _workplaceService = workPlaceService;
        }

        public async Task<IActionResult> HomePage()
        {
            var houses=await _houseService.GetAllHouses();
            return View(houses);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
