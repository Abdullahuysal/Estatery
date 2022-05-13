using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILandImageUrlService
    {
        Task<IResult> AddLandImageUrl(LandImageUrl landImageUrl);
        Task<List<LandImageUrl>> GetLandImageUrlById(int id);
    }
}
