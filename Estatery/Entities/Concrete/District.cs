using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class District:IEntity
    {
        public int DistrictId { get; set; }
        public String DistrictName { get; set; }
        public int? DistrictPostCode { get; set; }
        public int CityId { get; set; }
    }
}
