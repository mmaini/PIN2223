using Demo.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>()
            {
                new VillaDto{Id=1, Name="Villa1", Occupancy=4, Sqft=50},
                new VillaDto{Id=2, Name="Villa2", Occupancy=3, Sqft=40},
            };
    }
}
