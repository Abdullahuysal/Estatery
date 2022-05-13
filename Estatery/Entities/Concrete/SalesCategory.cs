using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SalesCategory:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<House> Houses{ get; set; }
        public virtual ICollection<Land> Lands{ get; set; }
        public virtual ICollection<WorkPlace> WorkPlaces { get; set; }
    }
}
