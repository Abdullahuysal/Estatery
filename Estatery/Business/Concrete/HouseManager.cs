using AutoMapper;
using Business.Abstract;
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
    public class HouseManager:IHouseService
    {
        private IHouseDal _houseDal;
        private IHouseConverter _houseConverter;

        public HouseManager(IHouseDal houseDal,IHouseConverter houseConverter)
        {
            _houseDal = houseDal;
            _houseConverter = houseConverter;
        }

        public async Task<IResult> AddHouse(AddHouseRequest addHouseRequest)
        {
            var house = _houseConverter.HouseDtoToHouse(addHouseRequest);
            await _houseDal.AddAsync(house);
            return new SuccessResult();
        }

        public Task<IResult> DeleteHouse(House house)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<House>> GetHouseById(int houseId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ICollection<House>>> GetAllHouses()
        {
            //var Houses= await _houseDal.GetAllAsync();
            // return new SuccessDataResult;
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateHouse(House house)
        {
            throw new NotImplementedException();
        }
    }
}
