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
        [HttpGet("getallhouse")]
        public async Task<IActionResult> GetAllHouses()
        {
            var result = await _houseService.GetAllHouses();
            return Ok(result);
        }
        [HttpPost("addhouse")]
        public async Task<IActionResult> AddHouse(HouseRequest houseRequest)
        {
            var result =await _houseService.AddHouse(houseRequest);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("gethousebyid")]
        public async Task<IActionResult> GetHouseById(int id)
        {
            var result = await _houseService.GetHouseById(id);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
