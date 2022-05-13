using Business.Abstract;
using AutoMapper;
using Business.Converter;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
using Business.Constants;

namespace Business.Concrete
{
    public class HouseManager:IHouseService
    {
        private IHouseDal _houseDal;
        private IHouseConverter _houseConverter;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        private IHouseImageUrlService _houseImageUrlService;
        private IMapper _mapper;
        public HouseManager(IHouseDal houseDal,IHouseConverter houseConverter,ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService, IHouseImageUrlService houseImageUrlService,IMapper mapper)
        {
            _houseDal = houseDal;
            _houseConverter = houseConverter;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
            _houseImageUrlService = houseImageUrlService;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(HouseValidator))]
        public async Task<IResult> AddHouse(HouseRequest houseRequest)
        { 
            var house = _houseConverter.HouseDtoToHouse(houseRequest);
            house =await FindHomeRelatedInformation(house);
            await _houseDal.AddAsync(house);
            await AddImageUrlToTable(house.HouseImageUrls, house);
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
            house.LocationId = location.Id;
            house.SalesCategoryId = salesCategory.Id;
            house.SalesTypeId = salesType.Id;
            return house;
        }
        private async Task AddImageUrlToTable(ICollection<HouseImageUrl> imageUrls,House house)
        {
            foreach (var imageUrl in imageUrls)
            {
                imageUrl.House = house;     
                await _houseImageUrlService.AddHouseImageUrl(imageUrl);
            }
        }
        public async Task<List<House>>  GetAllHouses()
        {
            List<House> houses = await _houseDal.GetAllAsync();
            houses =await GetHousedetails(houses);
            return houses;
           
        }
        private async Task<List<House>> GetHousedetails(List<House> houses)
        {
            List<House> houseresponse = new List<House>();
            foreach (var house in houses)
            {  
               houseresponse.Add(await _houseConverter.housetohouseDetail(house));
            }
            return houseresponse;
        }

        public async Task<IResult> UpdateHouse(HouseUpdateRequest houseUpdateRequest)
        {
            var house = await _houseConverter.HouseUpdateRequestTohouse(houseUpdateRequest);
            var result = await _houseDal.UpdateAsync(house);
            if (result != null)
            {
                await _houseImageUrlService.UpdateHouseImageUrl(house.Id, house.HouseImageUrls.First());
                return new SuccessResult();
            }
            return new ErrorResult(BusinessMessages.UpdateFailed);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _houseDal.IsExist(id);
        }

        public async Task<HouseResponse> GetHouseById(int id)
        {
            House house = await _houseDal.GetHouseById(id);
            var houseresponse = _mapper.Map<HouseResponse>(house);
            return houseresponse;
        }
    }
}
