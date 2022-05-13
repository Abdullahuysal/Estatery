using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHouseDal : EfEntityRepositoryBase<House, EstateryDbContext>, IHouseDal
    {
        public async Task<House> GetHouseById(int id)
        {
            var house = await this.GetAsync(h => h.Id==id);
            return house;
        }

        public async Task<bool> IsExist(int id)
        {
            var house= await this.GetAsync(h => h.Id == id);
            if (house != null)
            {
                return true;
            }
            return false;
        }
    }
}
