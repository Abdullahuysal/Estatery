using Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Responses
{
    public class WorkPlaceResponse
    {
        public int Id { get; set; }
        public LocationResponse Location { get; set; }
        public SalesCategoryResponse SalesCategory { get; set; }
        public SalesTypeResponse SalesType { get; set; }
        public ImageUrlResponse WorkPlaceImageUrl { get; set; }
        public string Advertiser { get; set; }
        public int Price { get; set; }
    }
}
