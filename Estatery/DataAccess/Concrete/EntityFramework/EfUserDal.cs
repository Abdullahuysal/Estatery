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
    public class EfUserDal : EfEntityRepositoryBase<User, EstateryDbContext>, IUserDal
    {
        public async Task<bool> CheckUserEmailIsExist(string Email)
        {
            var result = await this.GetAsync(u => u.Email == Email);
           if (result == null)  return false;
           return true;
        }
    }
}
