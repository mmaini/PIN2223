﻿using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Dto
{
    public class VillaCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
    }
}
