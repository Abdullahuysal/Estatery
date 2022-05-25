using Business.Abstract;
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
    public class WorkPlaceController : ControllerBase
    {
        private IWorkPlaceService _workPlaceService;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        public WorkPlaceController(IWorkPlaceService workPlaceService, ILocationService locationService, ISalesCategoryService salesCategoryService, ISalesTypeService salesTypeService)
        {
            _workPlaceService = workPlaceService;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
        }
        [HttpGet("getallworkplaces")]
        public async Task<IActionResult> GetAllWorkPlaces()
        {
            var result = await _workPlaceService.GetAllWorkPlaces();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getworkplacebyid")]
        public async Task<IActionResult> GetWorkPlaceById(int id)
        {
            var result = await _workPlaceService.GetWorkPlaceById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
