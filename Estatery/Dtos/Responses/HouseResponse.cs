using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class HouseResponse
    {
        public string Advertiser { get; set; }
        public int ConstructionYear { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBath { get; set; }
        public int SquareMeter { get; set; }
    }
}
