using AutoMapper;
using Demo.Models;
using Demo.Models.Dto;
using Demo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly ILogger<VillaController> _logger;
        private readonly IMapper _mapper;

        public VillaController(ILogger<VillaController> logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetVillas()
        {
            _logger.LogInformation("Poziv GetVillas");
            try
            {
                IEnumerable<Villa> villaList = await _dbVilla.GetAll();
                return Ok(_mapper.Map<List<VillaDto>>(villaList));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");
            }
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetVilla(int id)
        {
            _logger.LogInformation($"Poziv GetVilla. Id = {id}");
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Id nije dobar");
                    return BadRequest("Id nije dobar");
                }
                else
                {
                    var villa = await _dbVilla.Get(x => x.Id == id);
                    if (villa == null)
                    {
                        _logger.LogError("Villa ne postoji");
                        return NotFound("Villa ne postoji");
                    }
                    else
                    {
                        return Ok(_mapper.Map<VillaDto>(villa));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");
            }
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateVilla([FromBody] VillaCreateDto villaDto)
        {
            _logger.LogInformation("Poziv CreateVilla.");
            try
            {
                if (!ModelState.IsValid || villaDto == null)
                {
                    _logger.LogError("Model nije dobar");
                    return BadRequest("Model nije dobar");
                }
                else
                {
                    Villa villa = _mapper.Map<Villa>(villaDto);
                    villa.CreatedDate = DateTime.Now;
                    await _dbVilla.Create(villa);
                    return Ok(_mapper.Map<VillaDto>(villa));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");

            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteVilla(int id)
        {
            _logger.LogInformation($"Poziv DeleteVilla. Id = {id}");
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Id nije dobar");
                    return BadRequest("Id nije dobar");
                }
                else
                {
                    var villa = await _dbVilla.Get(x => x.Id == id);
                    if (villa == null)
                    {
                        _logger.LogError("Villa ne postoji");
                        return NotFound("Villa ne postoji");
                    }
                    else
                    {
                        await _dbVilla.Remove(villa);
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");
            }

        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto villaDto)
        {
            _logger.LogInformation($"Poziv UpdateVilla. Id = {id}");
            try
            {
                if (villaDto == null || villaDto.Id != id)
                {
                    _logger.LogError("Id nije dobar");
                    return BadRequest("Id nije dobar");
                }
                else
                {
                    var villa = await _dbVilla.Get(x => x.Id == id, false);
                    if (villa == null)
                    {
                        _logger.LogError("Villa ne postoji");
                        return NotFound("Villa ne postoji");
                    }
                    else
                    {
                        villa = _mapper.Map<Villa>(villaDto);
                        villa.UpdatedDate = DateTime.Now;
                        await _dbVilla.Update(villa);
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");
            }
        }

    }
}
