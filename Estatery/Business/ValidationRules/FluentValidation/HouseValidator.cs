using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class HouseValidator:AbstractValidator<House>
    {
        public HouseValidator()
        {
            RuleFor(h => h.Advertiser).NotEmpty();
            RuleFor(h => h.ConstructionYear).NotEmpty();
            RuleFor(h => h.NumberOfRooms).NotEmpty();
            RuleFor(h => h.NumberOfBath).NotEmpty();
            RuleFor(h => h.SquareMeter).NotEmpty();
            RuleFor(h => h.Location.CityName).NotEmpty();
            RuleFor(h => h.Location.DistrictName).NotEmpty();
            RuleFor(h => h.SalesCategory.Name).NotEmpty();
            RuleFor(h => h.SalesType.Name).NotEmpty();
        }
    }
}
