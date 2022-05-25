using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        Task<bool> CheckUserEmailIsExist(string Email);
        Task<User> GetUserById(int id);
        Task<string> getUserEmail(string username);
    }
}
