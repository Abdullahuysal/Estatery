using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkPlace:RealEstate,IEntity
    {
        public int Price { get; set; }
        public int SquareMeter { get; set; }
        
    }
}
