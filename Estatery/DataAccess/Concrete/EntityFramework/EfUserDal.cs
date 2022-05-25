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

        public async Task<User> GetUserById(int id)
        {
            var user = await this.GetAsync(u => u.Id == id);
            return user;
        }

        public async Task<string> getUserEmail(string username)
        {
            var user = await this.GetAsync(u => u.FirstName == username);
            return user.Email;
        }
    }
}
