using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Land:RealEstate,IEntity
    {
        public int SquareMeter { get; set; }
        public virtual ICollection<LandImageUrl> LandImageUrls { get; set; }

    }
}
