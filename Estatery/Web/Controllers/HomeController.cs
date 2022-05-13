using Business.Abstract;
using Dtos.Requests;
using Dtos.Responses;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHouseService _houseService;
        private IWorkPlaceService _workplaceService;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        public HomeController(ILogger<HomeController> logger,IHouseService houseService,IWorkPlaceService workPlaceService,ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService)
        {
            _logger = logger;
            _houseService = houseService;
            _workplaceService = workPlaceService;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
        }

        public async Task<IActionResult> HomePage()
        {
            var houses=await _houseService.GetAllHouses();
            return View(houses);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> locationItems =await getLocationForDropDown();
            List<SelectListItem> salescategoryItems = await getsalesCategoryForDropDown();
            List<SelectListItem> salestypeItems = await getsalesTypeForDropDown();
            ViewBag.Locations = locationItems;
            ViewBag.salescategoryItems = salescategoryItems;
            ViewBag.salestypeItems = salestypeItems;
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
                       Value =salestype.Name.ToString()
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
                    Text = location.CityName +"/"+ location.DistrictName,
                    Value = location.Id.ToString()
                });
            }
            return selectedItems;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(HouseRequest houseRequest)
        {
            var houseinfo = _locationService.GetLocationById(Convert.ToInt32(houseRequest.Location.CityName));
            houseRequest.Location.CityName = houseinfo.Result.CityName;
            houseRequest.Location.DistrictName = houseinfo.Result.DistrictName;
            var house =await _houseService.AddHouse(houseRequest);
            return RedirectToAction(nameof(HomePage));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            if (await _houseService.IsExist(id))
            {
                HouseResponse houseResponse = await _houseService.GetHouseById(id);
                List<SelectListItem> locationItems = await getLocationForDropDown();
                List<SelectListItem> salescategoryItems = await getsalesCategoryForDropDown();
                List<SelectListItem> salestypeItems = await getsalesTypeForDropDown();
                ViewBag.Locations = locationItems;
                ViewBag.salescategoryItems = salescategoryItems;
                ViewBag.salestypeItems = salestypeItems;
                return View(houseResponse);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(HouseUpdateRequest houseUpdateRequest)
        {
            if (ModelState.IsValid)
            {
                var houseinfo= _locationService.GetLocationById(Convert.ToInt32(houseUpdateRequest.Location.CityName));
                houseUpdateRequest.Location.CityName = houseinfo.Result.CityName;
                houseUpdateRequest.Location.DistrictName = houseinfo.Result.DistrictName;
                houseUpdateRequest.Location.Id = houseinfo.Result.Id;
                var result= await _houseService.UpdateHouse(houseUpdateRequest);
                if (result.Success == true)
                {
                    return RedirectToAction(nameof(HomePage));
                }
                return BadRequest();
            }
            return View();
        }
    }
}
