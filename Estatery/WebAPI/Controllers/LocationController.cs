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
    public class LocationController : ControllerBase
    {
        private ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpPost]
        public IActionResult AddLocation(LocationRequest locationRequest)
        {
            var result = _locationService.AddLocation(locationRequest);
            if (result.Result.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Result);
        }

    }
}
