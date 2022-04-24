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
        public ICollection<House> Houses{ get; set; }
        public ICollection<Land> Lands{ get; set; }
        public ICollection<WorkPlace> WorkPlaces { get; set; }
    }
}
