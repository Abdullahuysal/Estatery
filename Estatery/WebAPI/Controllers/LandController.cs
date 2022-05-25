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
    public class LandController : ControllerBase
    {
        private ILandService _landService;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        public LandController(ILandService landService, ILocationService locationService, ISalesCategoryService salesCategoryService, ISalesTypeService salesTypeService)
        {
            _landService = landService;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
        }
        [HttpGet("getallland")]
        public async Task<IActionResult> GetAllLand()
        {
            var result = await _landService.GetAllLands();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getlandbyid")]
        public async Task<IActionResult> GetLandById(int id)
        {
            var result = await _landService.GetLandById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("addland")]
        public async Task<IActionResult> Addland(LandRequest landRequest)
        {
            var result = await _landService.AddLand(landRequest);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateland")]
        public async Task<IActionResult> Update(LandUpdateRequest landUpdateRequest)
        {
            var landinfo = _landService.GetLandById(Convert.ToInt32(landUpdateRequest.Id));
            landUpdateRequest.Location.CityName = landinfo.Result.Location.CityName;
            landUpdateRequest.Location.DistrictName = landinfo.Result.Location.DistrictName;
            landUpdateRequest.Location.Id = landinfo.Result.Id;
            var result = await _landService.UpdateLand(landUpdateRequest);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
