using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Models.Dto
{
    public class VillaNumberDto
    {
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
