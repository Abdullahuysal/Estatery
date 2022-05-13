using AutoMapper;
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
    public class WorkPlaceManager : IWorkPlaceService
    {
        private IWorkPlaceDal _workPlaceDal;
        private IWorkPlaceConverter _workPlaceConverter;
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        private IWorkPlaceImageUrlService _workPlaceImageUrlService;
        private IMapper _mapper;
        public WorkPlaceManager(IWorkPlaceDal workPlaceDal,IWorkPlaceConverter workPlaceConverter,ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService, IWorkPlaceImageUrlService workPlaceImageUrlService, IMapper mapper)
        {
            _workPlaceDal = workPlaceDal;
            _workPlaceConverter = workPlaceConverter;
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
            _workPlaceImageUrlService = workPlaceImageUrlService;
            _mapper = mapper;
        }
        public Task<IResult> AddWorkPlace(WorkPlaceRequest workPlaceRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteWorkPlace(WorkPlaceRequest workPlaceRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkPlace>> GetAllWorkPlaces()
        {
            List<WorkPlace> workPlaces = await _workPlaceDal.GetAllAsync();
            workPlaces = await GetWorkPlaceDetails(workPlaces);
            return workPlaces;
        }

        private async Task<List<WorkPlace>> GetWorkPlaceDetails(List<WorkPlace> workPlaces)
        {
            List<WorkPlace> workPlaceresponse = new List<WorkPlace>();
            foreach (var workplace in workPlaces)
            {
                workPlaceresponse.Add(await _workPlaceConverter.WorkPlacetoWorkPlaceDetail(workplace));
            }
            return workPlaceresponse;
        }

        public Task<WorkPlaceResponse> GetWorkPlaceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateWorkPlace(WorkPlaceUpdateRequest workPlaceUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
