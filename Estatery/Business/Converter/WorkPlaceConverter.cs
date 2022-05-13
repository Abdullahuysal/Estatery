using Business.Abstract;
using Dtos.Requests;
using Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public class WorkPlaceConverter : IWorkPlaceConverter
    {
        private ILocationService _locationService;
        private ISalesCategoryService _salesCategoryService;
        private ISalesTypeService _salesTypeService;
        private IWorkPlaceImageUrlService _workplaceImageUrlService;
        public WorkPlaceConverter(ILocationService locationService,ISalesCategoryService salesCategoryService,ISalesTypeService salesTypeService,IWorkPlaceImageUrlService workPlaceImageUrlService)
        {
            _locationService = locationService;
            _salesCategoryService = salesCategoryService;
            _salesTypeService = salesTypeService;
            _workplaceImageUrlService = workPlaceImageUrlService;
        }
        public Task<WorkPlace> WorkPlaceDtoToWorkPlace(WorkPlaceRequest workPlaceRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkPlace> WorkPlacetoWorkPlaceDetail(WorkPlace workPlace)
        {
            var workplacelocation = new Location();
            var workplacesalescategory = new SalesCategory();
            var workplacesalestype = new SalesType();
            var workplaceimageUrls = new List<WorkPlaceImageUrl>();
            workplacelocation = await _locationService.GetLocationById(workPlace.LocationId);
            workplacesalescategory = await _salesCategoryService.GetSalesCategoryById(workPlace.SalesCategoryId);
            workplacesalestype = await _salesTypeService.GetSalesTypeById(workPlace.SalesTypeId);
            workplaceimageUrls = await _workplaceImageUrlService.GetWorkPlaceImageUrlById(workPlace.Id);
            workPlace.Location = workplacelocation;
            workPlace.SalesCategory = workplacesalescategory;
            workPlace.SalesType = workplacesalestype;
            workPlace.WorkPlaceImageUrls = workplaceimageUrls;
            return workPlace;
        }
    }
}
