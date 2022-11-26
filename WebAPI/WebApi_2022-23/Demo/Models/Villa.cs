﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Villa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
