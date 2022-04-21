using Business.Abstract;
using Entities.Concrete;
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
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _houseService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add(House house)
        {
            var result = _houseService.Add(house);
            return Ok(result);
        }
    }
}
