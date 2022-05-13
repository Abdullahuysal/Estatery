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
    public interface IHouseImageUrlService
    {
        Task<IResult> AddHouseImageUrl(HouseImageUrl houseImageUrl);
        Task<List<HouseImageUrl>> GetHouseImageUrlById(int HouseImageUrlId);
        Task<IResult> UpdateHouseImageUrl(int HouseImageUrlId, HouseImageUrl houseImageUrl);
    }
}
