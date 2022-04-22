﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Location
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }

    }
}