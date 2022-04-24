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
    public interface IHouseService
    {
        Task<IDataResult<ICollection<House>>> GetAllHouses();
        Task<IDataResult<House>> GetHouseById(int houseId);
        Task<IResult> AddHouse(AddHouseRequest addHouseRequest);
        Task<IResult> UpdateHouse(House house);
        Task<IResult> DeleteHouse(House house);

    }
}
