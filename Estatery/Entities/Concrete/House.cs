using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class House:RealEstate,IEntity
    {
        public int ConstructionYear { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBath { get; set; }
        public int SquareMeter { get; set; }

    }

}
