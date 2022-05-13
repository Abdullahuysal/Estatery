using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class WorkPlaceController : Controller
    {
        private IWorkPlaceService _workPlaceService;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        public WorkPlaceController(IWorkPlaceService workPlaceService,ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService)
        {
            _workPlaceService = workPlaceService;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
        }
        public async Task<IActionResult> WorkPlacePage()
        {
            var workplaces = await _workPlaceService.GetAllWorkPlaces();
            return View(workplaces);
        }

    }
}
