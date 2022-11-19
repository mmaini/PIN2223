using Demo.Data;
using Demo.Models;
using Demo.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDto> GetVillas()
        {
            return VillaStore.VillaList;
        }

        [HttpGet("{id:int}")]
        public VillaDto GetVilla(int id)
        {
            return VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
        }

    }
}
