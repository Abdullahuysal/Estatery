﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role:IEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
