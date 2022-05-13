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
    public interface IWorkPlaceService
    {
        Task<List<WorkPlace>> GetAllWorkPlaces();
        Task<IResult> AddWorkPlace(WorkPlaceRequest workPlaceRequest);
        Task<IResult> UpdateWorkPlace(WorkPlaceUpdateRequest workPlaceUpdateRequest);
        Task<IResult> DeleteWorkPlace(WorkPlaceRequest workPlaceRequest);
        Task<WorkPlaceResponse> GetWorkPlaceById(int id);
    }
}
