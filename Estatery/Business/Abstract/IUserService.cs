using Core.Utilities.Results;
using Dtos.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> ValidateUser(UserLoginRequest userLoginRequest);
        Task<IDataResult<User>> SignupUser(UserSignupRequest userSignupRequest);
        Task<IDataResult<User>> GetUserById(int id);
        Task<IResult>UpdateUser(UserUpdateRequest userUpdateRequest);
        Task<string> GetUserEmail(string username);
        Task<IResult> DeleteUser(int userid);
    }
}
