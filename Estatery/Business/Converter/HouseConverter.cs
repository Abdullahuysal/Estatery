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
        private IHouseImageUrlService _houseImageUrlService;
        public HouseConverter(ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService,IHouseImageUrlService houseImageUrlService)
        {
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
            _houseImageUrlService = houseImageUrlService;
        }
        public House HouseDtoToHouse(HouseRequest houseRequest)
        {
            House house = new House();
            Location location = new Location();
            SalesType salesType = new SalesType();
            SalesCategory salesCategory = new SalesCategory();
            List<HouseImageUrl> houseImageUrls = new List<HouseImageUrl>();
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
            foreach (var url in houseRequest.ImageUrls.Name)
            {
                HouseImageUrl houseImageUrl = new HouseImageUrl();
                houseImageUrl.Name = url;
                houseImageUrls.Add(houseImageUrl);
            }

            house.HouseImageUrls = houseImageUrls;
            house.Location= location;
            house.SalesType = salesType;
            house.SalesCategory = salesCategory;
            return house;
        }

        public async Task<House> housetohouseDetail(House house)
        {
            var houselocation = new Location();
            var housesalescategory = new SalesCategory();
            var housesalestype = new SalesType();
            var houseimageUrls = new List<HouseImageUrl>();
            houselocation = await _locationService.GetLocationById(house.LocationId);
            housesalescategory = await _salesCategoryService.GetSalesCategoryById(house.SalesCategoryId);
            housesalestype = await _salesTypeService.GetSalesTypeById(house.SalesTypeId);
            houseimageUrls = await _houseImageUrlService.GetHouseImageUrlById(house.Id);
            house.HouseImageUrls = houseimageUrls;
            house.Location = houselocation;
            house.SalesCategory = housesalescategory;
            house.SalesType = housesalestype;
            return house;
        }

        public  async Task<House> HouseUpdateRequestTohouse(HouseUpdateRequest houseUpdateRequest)
        {
            var house = new House();
            var houseimageUrls = new List<HouseImageUrl>();
            var houseimageurl = new HouseImageUrl();
            house.CreatedAt = DateTime.Now;
            house.UpdatedAt = DateTime.Now;
            house.Advertiser = houseUpdateRequest.Advertiser;
            house.ConstructionYear = houseUpdateRequest.ConstructionYear;
            house.NumberOfBath = houseUpdateRequest.NumberOfBath;
            house.NumberOfRooms = houseUpdateRequest.NumberOfRooms;
            house.SquareMeter = houseUpdateRequest.SquareMeter;
            var houselocation = await _locationService.GetLocation(houseUpdateRequest.Location.CityName, houseUpdateRequest.Location.DistrictName);
            var housesalescategory = await _salesCategoryService.GetSalesCategory(houseUpdateRequest.SalesCategory.Name);
            var housesalestype = await _salesTypeService.GetSalesType(houseUpdateRequest.SalesType.Name);
            houseimageurl.Name = houseUpdateRequest.HouseimageUrl;
            houseimageUrls.Add(houseimageurl);
            // TODO:HOUSE SALES TYPE YOK HATA VAR HOUSESALES CATEORY İD =0 GELİYOR DÜZELT
            house.HouseImageUrls = houseimageUrls;
            house.Location = houselocation;
            house.SalesCategory = housesalescategory;
            house.SalesType = housesalestype;
            house.Id = houseUpdateRequest.Id;
            house.LocationId = houselocation.Id;
            house.SalesCategoryId = housesalescategory.Id;
            house.SalesTypeId = housesalestype.Id;
            return house;
        }
    }
}
