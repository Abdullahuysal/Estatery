using Business.Abstract;
using Dtos.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public class UserConverter : IUserConverter
    {
        public User UserRequestToUser(UserSignupRequest userSignupRequest)
        {
            User user = new User();
            user.FirstName = userSignupRequest.FirstName;
            user.SecondName = userSignupRequest.SecondName;
            user.Email = userSignupRequest.Email;
            user.Password = userSignupRequest.Password;
            user.Active = true;
            user.RoleId = 1;
            return user;
        }
    }
}
