using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Location:IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public virtual ICollection<House> Houses { get; set; }
        public virtual ICollection<Land> Lands { get; set; }
        public virtual ICollection<WorkPlace> WorkPlaces { get; set; }

    }
}
