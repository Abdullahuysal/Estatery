using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Requests
{
    public class LandUpdateRequest
    {
        public int Id { get; set; }
        public SalesType SalesType { get; set; }
        public SalesCategory SalesCategory { get; set; }
        public Location Location { get; set; }
        public LandImageUrlRequest ImageUrls { get; set; }
        public int SquareMeter { get; set; }
    }
}
