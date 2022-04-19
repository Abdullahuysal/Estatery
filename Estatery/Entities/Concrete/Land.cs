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
        public int Price { get; set; }
        public int Square { get; set; }
        public SalesType SalesType { get; set; }
    }
}
