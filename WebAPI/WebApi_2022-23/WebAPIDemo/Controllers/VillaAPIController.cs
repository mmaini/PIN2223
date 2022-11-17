using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Data;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Dto;
using WebAPIDemo.Repository.IRepository;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly ILogger<VillaAPIController> _logger;
        private readonly IMapper _mapper;

        public VillaAPIController(ILogger<VillaAPIController> logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            _logger.LogInformation("Getting all villas");

            IEnumerable<Villa> villaList = await _dbVilla.GetAll();
            return Ok(_mapper.Map<List<VillaDto>>(villaList));
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.Get(x => x.Id == id);
            if(villa== null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDto>(villa));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CreateVilla([FromBody] VillaCreateDto villaDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (villaDto == null) return BadRequest(villaDto);

            Villa villa = _mapper.Map<Villa>(villaDto);
            villa.CreatedDate = DateTime.Now;
            await _dbVilla.Create(villa);
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0) return BadRequest();

            var villa = await _dbVilla.Get(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            await _dbVilla.Remove(villa);
            return NoContent();
        }

         [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDto villaDto)
        {
            if (villaDto == null || villaDto.Id != id) return BadRequest();

            var villa = await _dbVilla.Get(x => x.Id == id, false);
            if (villa == null)
            {
                return NotFound();
            }

            villa = _mapper.Map<Villa>(villaDto);
            villa.UpdatedDate = DateTime.Now;

            await _dbVilla.Update(villa);
            return NoContent();

        }


        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id==0) return BadRequest();
            //ne želimo pratiti ovaj objekt jer u update-u šaljemo izmijenjeni
            var villa = await _dbVilla.Get(x => x.Id == id, false);

            if (villa == null)
            {
                return NotFound();
            }

            //moramo kreirati dto za patch
            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);
                           
            patchDto.ApplyTo(villaDto, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            villa = _mapper.Map<Villa>(villaDto);
            villa.UpdatedDate = DateTime.Now;

            await _dbVilla.Update(villa);
            return NoContent();
        }
    }
}
