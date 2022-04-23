using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public abstract class RealEstate
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Advertiser { get; set; }
        //Navigation Properties
        public SalesCategory SalesCategory { get; set; }
        public int? SalesCategoryId { get; set; }
        public Location Location { get; set; }
        public int? LocationId { get; set; }
        public SalesType SalesType { get; set; }
        public int? SalesTypeId { get; set; }



    }
}
