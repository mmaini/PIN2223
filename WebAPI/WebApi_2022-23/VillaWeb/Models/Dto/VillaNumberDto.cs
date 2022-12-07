﻿using System.ComponentModel.DataAnnotations;

namespace VillaWeb.Models.Dto
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
        public VillaDto Villa { get; set; }
    }
}
