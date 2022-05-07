using Business.Abstract;
using Business.Constants;
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
    public class UserManager:IUserService
    {
        private  IUserDal _userDal;
        private IUserConverter _userConverter;

        public UserManager(IUserDal userDal,IUserConverter userConverter)
        {
            _userDal = userDal;
            _userConverter = userConverter;
        }

        public async Task<IDataResult<User>> SignupUser(UserSignupRequest userSignupRequest)
        {
            User newUser = _userConverter.UserRequestToUser(userSignupRequest);
            var result = IsExist(newUser);
            if (result != null)
            {
                await _userDal.AddAsync(newUser);
                return new SuccessDataResult<User>(newUser, BusinessMessages.AddSuccessfull);
            }
            return new ErrorDataResult<User>(BusinessMessages.AddFailed);
            
        }

        public async Task<IDataResult<User>> ValidateUser(UserLoginRequest userLoginRequest)
        {
           var user=await FindUserInfo(userLoginRequest.Email, userLoginRequest.Password);
            if (user != null)
            {
                return new SuccessDataResult<User>(user, BusinessMessages.GetSuccessfull);
            }
            return new ErrorDataResult<User>(BusinessMessages.GetFailed);
        }
        private async Task<User> FindUserInfo(string email,string password)
        {
            return await _userDal.GetAsync(u => u.Email == email && u.Password == password);
        }
        private async Task<User> IsExist(User user)
        {
            var result = await _userDal.GetAsync(u => u.Email == user.Email);
            if (result!=null) return null;
            return result;
        }
    }
}
