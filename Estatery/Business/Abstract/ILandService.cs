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
    public interface ILandService
    {
        Task<List<Land>> GetAllLands();
        Task<Land> FindLandRelatedInformation(Land land);
        Task<IResult> AddLand(LandRequest landRequest);
        Task<IResult> UpdateLand(LandUpdateRequest landUpdateRequest);
        Task<IResult> DeleteLand(LandRequest landRequest);
        Task<LandResponse> GetLandById(int Id);
        Task<bool> IsExist(int id);
    }
}
