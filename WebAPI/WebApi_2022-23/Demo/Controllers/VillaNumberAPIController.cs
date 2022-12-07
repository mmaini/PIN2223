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
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IVillaRepository _dbVilla;
        private readonly ILogger<VillaNumberAPIController> _logger;
        private readonly IMapper _mapper;

        public VillaNumberAPIController(ILogger<VillaNumberAPIController> logger, IVillaNumberRepository dbVillaNumber, IMapper mapper, IVillaRepository dbVilla)
        {
            _logger = logger;
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _dbVilla = dbVilla;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetVillaNumbers()
        {
            _logger.LogInformation("Poziv GetVillaNumbers");

            try
            {
                IEnumerable<VillaNumber> villaList = await _dbVillaNumber.GetAll();
                return Ok(_mapper.Map<List<VillaNumberDto>>(villaList));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");
            }                             
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetVillaNumber(int id)
        {
            _logger.LogInformation($"Poziv GetVillaNumber. Id = {id}");
            try
            {               
                if (id == 0)
                {
                    _logger.LogError("Id nije dobar");
                    return BadRequest("Id nije dobar");
                }
                else
                {
                    var villaNumber = await _dbVillaNumber.Get(x => x.VillaNo == id);
                    if (villaNumber == null)
                    {
                        _logger.LogError("VillaNumber ne postoji");
                        return NotFound("VillaNumber ne postoji");
                    }
                    else
                    {
                        return Ok(_mapper.Map<VillaNumberDto>(villaNumber));
                    }               
                }          
            }
            catch(Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");
            }        

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateVillaNumber([FromBody] VillaNumberCreateDto villaNumberDto)
        {
            _logger.LogInformation("Poziv CreateVillaNumber");
            try
            {
                if (!ModelState.IsValid || villaNumberDto == null)
                {
                    _logger.LogError("Id nije dobar");
                    return BadRequest("Id nije dobar");
                }
                else
                {
                    if(await _dbVilla.Get(x=> x.Id == villaNumberDto.VillaID) == null)
                    {
                        _logger.LogError("Villa ne postoji");
                        return NotFound("Villa ne postoji");
                    }
                    else
                    {
                        VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaNumberDto);
                        villaNumber.CreatedDate = DateTime.Now;
                        await _dbVillaNumber.Create(villaNumber);
                        return Ok(villaNumberDto);
                    }               
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
        public async Task<ActionResult> DeleteVillaNumber(int id)
        {
            _logger.LogInformation($"Poziv DeleteVillaNumber. Id = {id}");
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Id nije dobar");
                    return BadRequest("Id nije dobar");
                }
                else
                {
                    var villaNumber = await _dbVillaNumber.Get(x => x.VillaNo == id);
                    if (villaNumber == null)
                    {
                        _logger.LogError("VillaNumber ne postoji");
                        return NotFound("VillaNumber ne postoji");
                    }
                    else
                    {
                        await _dbVillaNumber.Remove(villaNumber);
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

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateVillaNumber(int id, [FromBody]VillaNumberUpdateDto villaUpdateDto)
        {
            _logger.LogInformation($"Poziv UpdateVillaNumber. Id = {id}");
            try
            {
                if (villaUpdateDto == null || villaUpdateDto.VillaNo != id)
                {
                    _logger.LogError("Id nije dobar");
                    return BadRequest("Id nije dobar");
                }
                else
                {
                    if (await _dbVilla.Get(x => x.Id == villaUpdateDto.VillaID) == null)
                    {
                        _logger.LogError("Villa ne postoji");
                        return NotFound("Villa ne postoji");
                    }
                    else
                    {
                        var villaNumber = await _dbVillaNumber.Get(x => x.VillaNo == id, false);
                        if (villaNumber == null)
                        {
                            _logger.LogError("VillaNumber ne postoji");
                            return NotFound("VillaNumber ne postoji");
                        }
                        else
                        {
                            villaNumber = _mapper.Map<VillaNumber>(villaUpdateDto);
                            await _dbVillaNumber.Update(villaNumber);
                            return NoContent();
                        }
                    }
                 
                }
            }            
            catch(Exception ex)
            {
                _logger.LogError($"Došlo je do pogreške: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Molimo kontaktirajte administratora");
            }
        }

    }
}
