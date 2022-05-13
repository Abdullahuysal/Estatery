using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLandDal: EfEntityRepositoryBase<Land,EstateryDbContext>,ILandDal
    {
        public async Task<Land> GetLandById(int id)
        {
            var land = await this.GetAsync(l => l.Id == id);
            return land;
        }

        public async Task<bool> IsExist(int id)
        {
            var land = await this.GetAsync(l => l.Id == id);
            if (land != null)
            {
                return true;
            }
            return false;
        }
    }
}
