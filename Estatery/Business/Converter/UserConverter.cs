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
            Role role = new Role();
            user.FirstName = userSignupRequest.FirstName;
            user.SecondName = userSignupRequest.SecondName;
            user.Email = userSignupRequest.Email;
            user.Password = userSignupRequest.Password;
            user.Active = true;
            role.Name = "kullanıcı";
            user.Role = role;
            user.RoleId = 1;
            return user;
        }
    }
}
