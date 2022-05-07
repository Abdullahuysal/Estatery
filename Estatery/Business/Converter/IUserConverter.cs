using Dtos.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public interface IUserConverter
    {
        User UserRequestToUser(UserSignupRequest userSignupRequest);
    }
}
