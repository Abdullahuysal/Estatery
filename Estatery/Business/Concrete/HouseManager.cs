using Business.Abstract;
using DataAccess.Abstract;
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
        public HouseManager(IHouseDal houseDal)
        {
            _houseDal = houseDal;
        }
    }
}
