using Dtos.Requests;
using Dtos.Responses;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public interface IWorkPlaceConverter
    {
        Task<WorkPlace> WorkPlaceDtoToWorkPlace(WorkPlaceRequest workPlaceRequest);
        Task<WorkPlace> WorkPlacetoWorkPlaceDetail(WorkPlace workPlace);
    }
}
