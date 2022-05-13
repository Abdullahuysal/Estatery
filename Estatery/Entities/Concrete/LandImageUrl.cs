using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LandImageUrl: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Land Land { get; set; }
    }
}
