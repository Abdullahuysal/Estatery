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
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }
        [HttpGet("getallhouses")]
        public IActionResult GetAllHouses()
        {
            var result = _houseService.GetAllHouses();
            if (result.Result.Success)
            {
                return Ok(result.Result.Data);
            }
            return BadRequest(result.Result);
        }
        [HttpPost("addhouse")]
        public IActionResult AddHouse(HouseRequest houseRequest)
        {
            var result = _houseService.AddHouse(houseRequest);
            if (result.Result.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Result);
        }
    }
}
