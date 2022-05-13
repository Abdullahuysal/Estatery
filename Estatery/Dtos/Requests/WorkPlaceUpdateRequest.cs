using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class WorkPlaceUpdateRequest
    {
        public int Id { get; set; }
        public SalesTypeRequest SalesType { get; set; }
        public SalesCategoryRequest SalesCategory { get; set; }
        public LocationRequest Location { get; set; }
        public WorkPlaceImageUrlRequest ImageUrls { get; set; }
        public int Price { get; set; }
    }
}
