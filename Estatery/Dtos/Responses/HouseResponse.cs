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
        public int Id { get; set; }
        public LocationResponse Location { get; set; }
        public SalesCategoryResponse SalesCategory { get; set; }
        public SalesTypeResponse SalesType { get; set; }
        public ImageUrlResponse HouseimageUrl { get; set; }
        public string Advertiser { get; set; }
        public int ConstructionYear { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBath { get; set; }
        public int SquareMeter { get; set; }
    }
}
