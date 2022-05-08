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
        public LandConverter(ILocationService locationService, ISalesCategoryService salesCategoryService, ISalesTypeService salesTypeService)
        {
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
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
            land.ConstructionYear = land.ConstructionYear;
            land.NumberOfBath = land.NumberOfBath;
            land.NumberOfRooms = land.NumberOfRooms;
            land.SquareMeter = land.SquareMeter;
            location.CityName = land.Location.CityName;
            location.DistrictName = land.Location.DistrictName;
            salesType.Name = land.SalesType.Name;
            salesCategory.Name = land.SalesCategory.Name;
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
    }
}
