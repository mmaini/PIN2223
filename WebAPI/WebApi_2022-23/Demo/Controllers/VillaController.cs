using Demo.Data;
using Demo.Models;
using Demo.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        public VillaController(ILogger<VillaController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public ActionResult GetVillas()
        {
            _logger.LogInformation("Pozvana je metoda GetVillas");
            return Ok(VillaStore.VillaList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult GetVilla(int id)
        {
            if (id == 0) return BadRequest();
            VillaDto villa = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            if (villa == null) return NotFound();

            return Ok(villa);
        }

        [HttpPost]
        public ActionResult CreateVilla([FromBody] VillaDto villa)
        {
            if (villa == null) return BadRequest();
            villa.Id = VillaStore.VillaList.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            VillaStore.VillaList.Add(villa);
            return Ok(villa);
        }

        [HttpDelete]
        public ActionResult DeleteVilla(int id)
        {
            if (id == 0) return BadRequest();
            VillaDto villa = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            if (villa == null) return NotFound();

            VillaStore.VillaList.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateVilla(int id, [FromBody]VillaDto villa)
        {
            if (villa == null || id != villa.Id) return BadRequest();
            VillaDto v = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            if (v == null) return NotFound();
            v.Occupancy = villa.Occupancy;
            v.Name = villa.Name;
            v.Sqft = villa.Sqft;
            
            return NoContent();

        }

        [HttpPatch("{id:int}")]
        public ActionResult UpdatePartialUpdate(int id, JsonPatchDocument<VillaDto> villaDto)
        {
            VillaDto v = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            villaDto.ApplyTo(v, ModelState);
            if (!ModelState.IsValid) return BadRequest();

            return NoContent();
        }

    }
}
