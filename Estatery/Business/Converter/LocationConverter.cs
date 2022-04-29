using DataAccess.Abstract;
using Dtos.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public class LocationConverter : ILocationConverter
    {
        private ILocationDal _locationDal;
        public LocationConverter(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }
        public Location LocationDtoToLocation(LocationRequest locationRequest)
        {
            Location location = new Location();
            location.CityName = locationRequest.CityName;
            location.DistrictName = locationRequest.DistrictName;
            return location;
        }
    }
}
