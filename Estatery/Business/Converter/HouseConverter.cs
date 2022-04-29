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
    public class HouseConverter : IHouseConverter
    {
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        public HouseConverter(ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService)
        {
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;

        }
        public House HouseDtoToHouse(HouseRequest houseRequest)
        {
            House house = new House();
            Location location = new Location();
            SalesType salesType = new SalesType();
            SalesCategory salesCategory = new SalesCategory();
            house.CreatedAt = DateTime.Now;
            house.UpdatedAt = DateTime.Now;
            house.Advertiser = houseRequest.Advertiser;
            house.ConstructionYear = houseRequest.ConstructionYear;
            house.NumberOfBath = houseRequest.NumberOfBath;
            house.NumberOfRooms = houseRequest.NumberOfRooms;
            house.SquareMeter = houseRequest.SquareMeter;
            location.CityName = houseRequest.Location.CityName;
            location.DistrictName = houseRequest.Location.DistrictName;
            salesType.Name = houseRequest.SalesType.Name;
            salesCategory.Name = houseRequest.SalesCategory.Name;
            house.Location= location;
            house.SalesType = salesType;
            house.SalesCategory = salesCategory;
            return house;
        }

    }
}
