using Business.Abstract;
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
    public class HouseImageUrlManager : IHouseImageUrlService
    {
        private IHouseImageUrlDal _houseImageUrlDal;

        public HouseImageUrlManager(IHouseImageUrlDal houseImageUrlDal)
        {
            _houseImageUrlDal = houseImageUrlDal;
        }
        public async Task<IResult> AddHouseImageUrl(HouseImageUrl houseImageUrl)
        {
            await _houseImageUrlDal.AddAsync(houseImageUrl);
            return new SuccessResult();
        }
    }
}
