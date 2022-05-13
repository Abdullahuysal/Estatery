using Core.Utilities.Results;
using Dtos.Requests;
using Dtos.Responses;
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
        Task<List<House>> GetAllHouses();
        Task<bool> IsExist(int id);
        Task<House> FindHomeRelatedInformation(House house);
        Task<IResult> AddHouse(HouseRequest HouseRequest);
        Task<IResult> UpdateHouse(HouseUpdateRequest houseUpdateRequest);
        Task<IResult> DeleteHouse(HouseRequest houseRequest);
        Task<HouseResponse> GetHouseById(int id);
    }
}
