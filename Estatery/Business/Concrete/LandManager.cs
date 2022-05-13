using AutoMapper;
using Business.Abstract;
using Business.Constants;
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
    public class LandManager : ILandService
    {
        private ILandDal _landDal;
        private ILandConverter _landConverter;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        private ILandImageUrlService _landImageUrlService;
        private IMapper _mapper;
        public LandManager(ILandDal landDal,ILandConverter landConverter, ILocationService locationService, ISalesCategoryService salesCategoryService, ISalesTypeService salesTypeService,ILandImageUrlService landImageUrlService,IMapper mapper)
        {
            _landDal = landDal;
            _landConverter = landConverter;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
            _landImageUrlService = landImageUrlService;
            _mapper = mapper;
        }

        public async Task<IResult> AddLand(LandRequest landRequest)
        {
            var land = _landConverter.LandDtoToLand(landRequest);
            land = await FindLandRelatedInformation(land);
            await _landDal.AddAsync(land);
            await AddLandImagegUrlToTabel(land.LandImageUrls, land);
            return new SuccessResult();
        }

        private async Task AddLandImagegUrlToTabel(ICollection<LandImageUrl> landImageUrls, Land land)
        {
            foreach (var imageUrl in landImageUrls)
            {
                imageUrl.Land = land;
                await _landImageUrlService.AddLandImageUrl(imageUrl);
            }
        }

        public async Task<Land> FindLandRelatedInformation(Land land)
        {
            var location = await _locationService.GetLocation(land.Location.CityName, land.Location.DistrictName);
            var salesCategory = await _salesCategoryService.GetSalesCategory(land.SalesCategory.Name);
            var salesType = await _salesTypeService.GetSalesType(land.SalesType.Name);
            land.LocationId = location.Id;
            land.SalesCategoryId = salesCategory.Id;
            land.SalesTypeId = salesType.Id;
            return land;
        }

        public async Task<List<Land>> GetAllLands()
        {
            List<Land> lands = await _landDal.GetAllAsync();
            lands = await GetLanddetails(lands);
            return lands;
        }
        private async Task<List<Land>> GetLanddetails(List<Land> lands)
        {
            List<Land> landresponse = new List<Land>();
            foreach (var land in lands)
            {
                landresponse.Add(await _landConverter.landtoLandDetail(land));
            }
            return landresponse;
        }

        public async Task<LandResponse> GetLandById(int Id)
        {
            Land land = await _landDal.GetLandById(Id);
            var landresponse = _mapper.Map<LandResponse>(land);
            return landresponse;
        }

        public async Task<IResult> UpdateLand(LandUpdateRequest landUpdateRequest)
        {
            var land = _mapper.Map<Land>(landUpdateRequest);
            var result = await _landDal.UpdateAsync(land);
            if(result != null)
            {
                // Todo:2 land image url service update'i yazılacak 
                
                return new SuccessResult();
            }
            return new ErrorResult(BusinessMessages.UpdateFailed);
        }

        public Task<IResult> DeleteLand(LandRequest landRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _landDal.IsExist(id);
        }
    }
    }
