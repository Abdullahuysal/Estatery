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
using MailKit;
using MimeKit;

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

        public async Task<IResult> DeleteUser(int userid)
        {
            var user = await _userDal.GetAsync(u => u.Id==userid);
            user.Active = false;
            var result = await _userDal.UpdateAsync(user);
            if (result != null)
            {
                return new SuccessResult(BusinessMessages.DeleteSuccessfull);
            }
            return new ErrorResult(BusinessMessages.DeleteFailed);
        }

        public async Task<IDataResult<User>> GetUserById(int id)
        {
            var user = await _userDal.GetUserById(id);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>(BusinessMessages.GetFailed);
        }

        public async Task<string> GetUserEmail(string username)
        {
            var useremail = await _userDal.getUserEmail(username);
            if (useremail != null)
            {
                return useremail;
            }
            return null;
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

        public async Task<IResult> UpdateUser(UserUpdateRequest userUpdateRequest)
        {
            var user = _userConverter.UserupdateRequestToUser(userUpdateRequest);
            var result = await _userDal.UpdateAsync(user);
            if(result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(BusinessMessages.UpdateFailed);
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
