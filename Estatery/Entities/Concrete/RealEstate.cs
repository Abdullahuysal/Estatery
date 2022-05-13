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
        public int SalesCategoryId { get; set; }
        public int LocationId { get; set; }
        public int SalesTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Advertiser { get; set; }
        //Navigation Properties
        public virtual SalesCategory SalesCategory { get; set; }
        public virtual Location Location { get; set; }
        public virtual SalesType SalesType { get; set; }

    }
}
