using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class HouseRequest
    {
        public SalesTypeRequest SalesType { get; set; }
        public SalesCategoryRequest SalesCategory { get; set; }
        public LocationRequest Location { get; set; }
        public HouseImageUrlRequest ImageUrls { get; set; }
        public string Advertiser { get; set; }
        public int ConstructionYear { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBath { get; set; }
        public int SquareMeter { get; set; }
    }
}
