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

        public async Task<List<HouseImageUrl>> GetHouseImageUrlById(int HouseImageUrlId)
        {
            var houseimageurls = await _houseImageUrlDal.GetAllAsync(i => i.Id == HouseImageUrlId);
            return houseimageurls;
        }

        public async Task<IResult> UpdateHouseImageUrl(int HouseImageUrlId, HouseImageUrl houseImageUrl)
        {
            var houseimageurl = await GetHouseImageUrlById(HouseImageUrlId);
            houseImageUrl.Id = HouseImageUrlId;
            houseImageUrl.Name = houseImageUrl.Name;
            await _houseImageUrlDal.UpdateAsync(houseImageUrl);
            return new SuccessResult();
        }
    }
}
