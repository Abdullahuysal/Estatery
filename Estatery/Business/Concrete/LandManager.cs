using Business.Abstract;
using Business.Constants;
using Business.Converter;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Dtos.Requests;
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
        public LandManager(ILandDal landDal,ILandConverter landConverter, ILocationService locationService, ISalesCategoryService salesCategoryService, ISalesTypeService salesTypeService,ILandImageUrlService landImageUrlService)
        {
            _landDal = landDal;
            _landConverter = landConverter;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
            _landImageUrlService = landImageUrlService;
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
            land.LocationId = location.Data.Id;
            land.SalesCategoryId = salesCategory.Data.Id;
            land.SalesTypeId = salesType.Data.Id;
            return land;
        }

        public async Task<List<Land>> GetAllLands()
        {
            List<Land> lands = await _landDal.GetAllAsync();
            return lands;
        }

        public async Task<IDataResult<Land>> GetLandById(int Id)
        {
            var land = await _landDal.GetAsync(l => l.Id == Id);
            if (land != null)
            {
                return new SuccessDataResult<Land>(land);
            }
            return new ErrorDataResult<Land>(BusinessMessages.GetFailed);
        }

        public Task<IResult> UpdateLand(LandRequest landRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteLand(LandRequest landRequest)
        {
            throw new NotImplementedException();
        }
    }
    }
