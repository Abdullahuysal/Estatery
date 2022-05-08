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
    public class LandImageUrlManager : ILandImageUrlService
    {
        private ILandImageUrlDal _landImageUrlDal;
        public LandImageUrlManager(ILandImageUrlDal landImageUrlDal)
        {
            _landImageUrlDal = landImageUrlDal;
        }
        public async Task<IResult> AddLandImageUrl(LandImageUrl landImageUrl)
        {
            await _landImageUrlDal.AddAsync(landImageUrl);
            return new SuccessResult();
        }
       
    }
}
