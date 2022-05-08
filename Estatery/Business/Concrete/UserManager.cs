using Business.Abstract;
using Business.Constants;
using Business.Converter;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(UserValidator))]
        public async Task<IDataResult<User>> SignupUser(UserSignupRequest userSignupRequest)
        {
            if (await IsExistUserEmail(userSignupRequest.Email))
            {
                return new ErrorDataResult<User>(BusinessMessages.AddFailed);
            }
            User newUser = _userConverter.UserRequestToUser(userSignupRequest);
            await _userDal.AddAsync(newUser);
            return new SuccessDataResult<User>(newUser, BusinessMessages.AddSuccessfull);
            
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
        private async Task<bool> IsExistUserEmail(string UserEmail)
        {
            return await _userDal.CheckUserEmailIsExist(UserEmail);
        }
    }
}
