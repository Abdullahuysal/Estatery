using Business.Abstract;
using Dtos.Requests;
using Dtos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LandController : Controller
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
        public async Task<IActionResult> LandPage()
        {
            var lands = await _landService.GetAllLands();
            return View(lands);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> locationItems = await getLocationForDropDown();
            List<SelectListItem> salescategoryItems = await getsalesCategoryForDropDown();
            List<SelectListItem> salestypeItems = await getsalesTypeForDropDown();
            ViewBag.Locations = locationItems;
            ViewBag.salescategoryItems = salescategoryItems;
            ViewBag.salestypeItems = salestypeItems;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LandRequest landRequest)
        {
            var landinfo = _locationService.GetLocationById(Convert.ToInt32(landRequest.Location.CityName));
            landRequest.Location.CityName = landinfo.Result.CityName;
            landRequest.Location.DistrictName = landinfo.Result.DistrictName;
            var land = await _landService.AddLand(landRequest);
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            if (await _landService.IsExist(id))
            {
                LandResponse landResponse = await _landService.GetLandById(id);
                List<SelectListItem> locationItems = await getLocationForDropDown();
                List<SelectListItem> salescategoryItems = await getsalesCategoryForDropDown();
                List<SelectListItem> salestypeItems = await getsalesTypeForDropDown();
                ViewBag.Locations = locationItems;
                ViewBag.salescategoryItems = salescategoryItems;
                ViewBag.salestypeItems = salestypeItems;
                return View(landResponse);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(LandUpdateRequest landUpdateRequest)
        {
            if (ModelState.IsValid)
            {
                var landinfo = _landService.GetLandById(Convert.ToInt32(landUpdateRequest.Id));
                landUpdateRequest.Location.CityName = landinfo.Result.Location.CityName;
                landUpdateRequest.Location.DistrictName = landinfo.Result.Location.DistrictName;
                landUpdateRequest.Location.Id = landinfo.Result.Id;
                var result = await _landService.UpdateLand(landUpdateRequest);
                if (result.Success == true)
                {
                    return RedirectToAction(nameof(LandPage));
                }
                return BadRequest();
            }
            return View();
        }
        private async Task<List<SelectListItem>> getsalesTypeForDropDown()
        {
            var selectedItems = new List<SelectListItem>();
            var salesTypes = await _salesTypeService.GetAllSalesTypes();
            foreach (var salestype in salesTypes)
            {
                selectedItems.Add(
                   new SelectListItem
                   {
                       Text = salestype.Name,
                       Value = salestype.Name.ToString()
                   });
            }
            return selectedItems;
        }
        private async Task<List<SelectListItem>> getsalesCategoryForDropDown()
        {
            var selectedItems = new List<SelectListItem>();
            var salesCategories = await _salesCategoryService.GetAllSalesCategories();
            foreach (var salescategory in salesCategories)
            {
                selectedItems.Add(
                   new SelectListItem
                   {
                       Text = salescategory.Name,
                       Value = salescategory.Name.ToString()
                   });
            }
            return selectedItems;
        }
        private async Task<List<SelectListItem>> getLocationForDropDown()
        {
            var selectedItems = new List<SelectListItem>();
            var locations = await _locationService.GetAllLocations();
            foreach (var location in locations)
            {
                selectedItems.Add(
                new SelectListItem
                {
                    Text = location.CityName + "/" + location.DistrictName,
                    Value = location.Id.ToString()
                });
            }
            return selectedItems;
        }
    }
}
