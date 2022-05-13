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
    public class LocationManager : ILocationService
    {
        private ILocationDal _locationDal;
        private ILocationConverter _locationConverter;

        public LocationManager(ILocationDal locationDal,ILocationConverter locationConverter)
        {
            _locationDal = locationDal;
            _locationConverter = locationConverter;
        }

        public async Task<IResult> AddLocation(LocationRequest locationRequest)
        {
            Location location = _locationConverter.LocationDtoToLocation(locationRequest);
            if (location != null)
            {
               await _locationDal.AddAsync(location);
                return new SuccessResult(BusinessMessages.AddSuccessfull); 
            }
            return new ErrorResult(BusinessMessages.AddFailed);
        }

        public Task<IResult> DeleteLocation(LocationRequest locationRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> GetAllLocations()
        {
            var locations = await _locationDal.GetAllAsync();
            return locations;
        }

        public async Task<Location> GetLocation(string cityName, string districtName)
        {
            var location =await  _locationDal.GetAsync(l => l.CityName == cityName && l.DistrictName == districtName);
            if (location != null)
            {
                return (location);
            }
            return null;
        }

        public async Task<Location> GetLocationById(int locationId)
        {
            var location = await _locationDal.GetAsync(l => l.Id == locationId);
            return location;
        }

        public Task<IResult> UpdateLocation(LocationRequest locationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
