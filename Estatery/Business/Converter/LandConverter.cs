using Business.Abstract;
using Dtos.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public class LandConverter : ILandConverter
    {
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        private ILandImageUrlService _landImageUrlService;
        public LandConverter(ILocationService locationService, ISalesCategoryService salesCategoryService, ISalesTypeService salesTypeService, ILandImageUrlService landImageUrlService)
        {
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
            _landImageUrlService = landImageUrlService;
        }
        public Land LandDtoToLand(LandRequest landRequest)
        {
            Land land = new Land();
            Location location = new Location();
            SalesType salesType = new SalesType();
            SalesCategory salesCategory = new SalesCategory();
            List<LandImageUrl> landImageUrls = new List<LandImageUrl>();
            land.CreatedAt= DateTime.Now;
            land.UpdatedAt= DateTime.Now;
            land.Advertiser = landRequest.Advertiser;
            land.SquareMeter = landRequest.SquareMeter;
            location.CityName = landRequest.Location.CityName;
            location.DistrictName = landRequest.Location.DistrictName;
            salesType.Name = landRequest.SalesType.Name;
            salesCategory.Name = landRequest.SalesCategory.Name;
            foreach (var url in landRequest.ImageUrls.Name)
            {
                LandImageUrl landImageUrl = new LandImageUrl();
                landImageUrl.Name = url;
                landImageUrls.Add(landImageUrl);
            }
            land.LandImageUrls = landImageUrls;
            land.Location = location;
            land.SalesCategory = salesCategory;
            land.SalesType = salesType;
            return land;
        }

        public async Task<Land> landtoLandDetail(Land land)
        {
            var landlocation = new Location();
            var landsalescategory = new SalesCategory();
            var landsalestype = new SalesType();
            var landimageUrls = new List<LandImageUrl>();
            landlocation = await _locationService.GetLocationById(land.LocationId);
            landsalescategory = await _salesCategoryService.GetSalesCategoryById(land.SalesCategoryId);
            landsalestype = await _salesTypeService.GetSalesTypeById(land.SalesTypeId);
            landimageUrls = await _landImageUrlService.GetLandImageUrlById(land.Id);
            land.Location = landlocation;
            land.SalesCategory = landsalescategory;
            land.SalesType = landsalestype;
            land.LandImageUrls = landimageUrls;
            return land;
        }
            public Task<Land> LandUpdateRequestToLand(LandUpdateRequest landUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
