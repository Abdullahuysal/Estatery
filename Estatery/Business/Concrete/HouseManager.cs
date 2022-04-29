using Business.Abstract;
using Business.Converter;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Dtos.Requests;
using Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HouseManager:IHouseService
    {
        private IHouseDal _houseDal;
        private IHouseConverter _houseConverter;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;

        public HouseManager(IHouseDal houseDal,IHouseConverter houseConverter,ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService)
        {
            _houseDal = houseDal;
            _houseConverter = houseConverter;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
        }

        public async Task<IResult> AddHouse(HouseRequest houseRequest)
        { 
            var house = _houseConverter.HouseDtoToHouse(houseRequest);
            house =await FindHomeRelatedInformation(house);
            await _houseDal.AddAsync(house);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteHouse(HouseRequest houseRequest)
        {
            var house = _houseConverter.HouseDtoToHouse(houseRequest);
            await _houseDal.DeleteAsync(house);
            return new SuccessResult();
        }

        public async Task<House> FindHomeRelatedInformation(House house)
        {
            var location = await _locationService.GetLocation(house.Location.CityName, house.Location.DistrictName);
            var salesCategory = await _salesCategoryService.GetSalesCategory(house.SalesCategory.Name);
            var salesType = await _salesTypeService.GetSalesType(house.SalesType.Name);
            house.LocationId = location.Data.Id;
            house.SalesCategoryId = salesCategory.Data.Id;
            house.SalesTypeId = salesType.Data.Id;
            return house;
        }

        public Task<IDataResult<ICollection<House>>> GetAllHouses()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateHouse(HouseRequest houseRequest)
        {
            throw new NotImplementedException();
        }
    }
}
