using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            _logger.LogInformation("Getting all villas");
            APIResponse response = new();
            try
            {
                IEnumerable<Villa> villaList = await _dbVilla.GetAll();
                response.Result = _mapper.Map<List<VillaDto>>(villaList);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.ToString());
            }                             
            return response;
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            APIResponse response = new();
            try
            {               
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.StatusCode =  HttpStatusCode.BadRequest;
                    response.ErrorMessages.Add("ID nije dobar");
                }
                else
                {
                    var villa = await _dbVilla.Get(x => x.Id == id);
                    if (villa == null)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.ErrorMessages.Add("Villa ne postoji");
                    }
                    else
                    {
                        response.Result = _mapper.Map<VillaDto>(villa);
                        response.StatusCode = HttpStatusCode.OK;
                    }               
                }          
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.ToString());
            }        
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDto villaDto)
        {
            APIResponse response = new();
            try
            {
                if (!ModelState.IsValid || villaDto == null)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.ErrorMessages.Add("ID nije dobar");
                }
                else
                {
                    Villa villa = _mapper.Map<Villa>(villaDto);
                    villa.CreatedDate = DateTime.Now;
                    await _dbVilla.Create(villa);

                    response.StatusCode = HttpStatusCode.Created;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.ToString());

            }
            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            APIResponse response = new();
            try
            {
                if (id == 0)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.ErrorMessages.Add("ID nije dobar");
                }
                else
                {
                    var villa = await _dbVilla.Get(x => x.Id == id);
                    if (villa == null)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.ErrorMessages.Add("Villa ne postoji");
                    }
                    else
                    {
                        await _dbVilla.Remove(villa);
                        response.StatusCode = HttpStatusCode.NoContent;
                    }
                }                   
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages.Add(ex.ToString());
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody]VillaUpdateDto villaDto)
        {
            APIResponse response = new();
            try
            {
                if (villaDto == null || villaDto.Id != id)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.ErrorMessages.Add("ID nije dobar");                   
                }
                else
                {
                    var villa = await _dbVilla.Get(x => x.Id == id, false);
                    if (villa == null)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.ErrorMessages.Add("Villa ne postoji");
                    }
                    else
                    {
                        villa = _mapper.Map<Villa>(villaDto);
                        villa.UpdatedDate = DateTime.Now;
                        await _dbVilla.Update(villa);
                        response.StatusCode = HttpStatusCode.NoContent;
                    }
                }
            }            
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages.Add(ex.ToString());
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }


        #region NotUsed
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0) return BadRequest();
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

        #endregion

    }
}
