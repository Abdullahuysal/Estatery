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
    public interface ILocationService
    {
        Task<Location> GetLocation(string cityName,string districtName);
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationById(int locationId);
        Task<IResult> AddLocation(LocationRequest locationRequest);
        Task<IResult> UpdateLocation(LocationRequest locationRequest);
        Task<IResult> DeleteLocation(LocationRequest locationRequest);
    }
}
