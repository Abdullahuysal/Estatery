using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkPlaceImageUrlManager : IWorkPlaceImageUrlService
    {
        private IWorkPlaceImageUrlDal _workPlaceImageUrlDal;
        public WorkPlaceImageUrlManager(IWorkPlaceImageUrlDal workPlaceImageUrlDal)
        {
            _workPlaceImageUrlDal = workPlaceImageUrlDal;
        }
        public async Task<IResult> AddWorkPlaceImageUrl(WorkPlaceImageUrl workPlaceImageUrl)
        {
            await _workPlaceImageUrlDal.AddAsync(workPlaceImageUrl);
            return new SuccessResult();
        }
    }
}
