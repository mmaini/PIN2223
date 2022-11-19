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
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            _logger.LogInformation("Getting all villa numbers");
            APIResponse response = new();
            try
            {
                IEnumerable<VillaNumber> villaList = await _dbVillaNumber.GetAll();
                response.Result = _mapper.Map<List<VillaNumberDto>>(villaList);
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

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
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
                    var villaNumber = await _dbVillaNumber.Get(x => x.VillaNo == id);
                    if (villaNumber == null)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.ErrorMessages.Add("VillaNumber ne postoji");
                    }
                    else
                    {
                        response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
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
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto villaNumberDto)
        {
            APIResponse response = new();
            try
            {
                if (!ModelState.IsValid || villaNumberDto == null)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.ErrorMessages.Add("ID nije dobar");
                }
                else
                {
                    if(await _dbVilla.Get(x=> x.Id == villaNumberDto.VillaID) == null)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.ErrorMessages.Add("Villa ne postoji");
                    }
                    else
                    {
                        VillaNumber villaNumber = _mapper.Map<VillaNumber>(villaNumberDto);
                        villaNumber.CreatedDate = DateTime.Now;
                        await _dbVillaNumber.Create(villaNumber);
                        response.StatusCode = HttpStatusCode.Created;
                    }               
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
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
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
                    var villaNumber = await _dbVillaNumber.Get(x => x.VillaNo == id);
                    if (villaNumber == null)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.ErrorMessages.Add("Villa ne postoji");
                    }
                    else
                    {
                        await _dbVillaNumber.Remove(villaNumber);
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

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody]VillaNumberUpdateDto villaUpdateDto)
        {
            APIResponse response = new();
            try
            {
                if (villaUpdateDto == null || villaUpdateDto.VillaNo != id)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.ErrorMessages.Add("ID nije dobar");                   
                }
                else
                {
                    if (await _dbVilla.Get(x => x.Id == villaUpdateDto.VillaID) == null)
                    {
                        response.IsSuccess = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.ErrorMessages.Add("Villa ne postoji");
                    }
                    else
                    {
                        var villaNumber = await _dbVillaNumber.Get(x => x.VillaNo == id, false);
                        if (villaNumber == null)
                        {
                            response.IsSuccess = false;
                            response.StatusCode = HttpStatusCode.NotFound;
                            response.ErrorMessages.Add("VillaNumber ne postoji");
                        }
                        else
                        {
                            villaNumber = _mapper.Map<VillaNumber>(villaUpdateDto);
                            await _dbVillaNumber.Update(villaNumber);
                            response.StatusCode = HttpStatusCode.NoContent;
                        }
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
        //[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        //{
        //    if (patchDto == null || id==0) return BadRequest();
        //    //ne želimo pratiti ovaj objekt jer u update-u šaljemo izmijenjeni
        //    var villa = await _dbVilla.Get(x => x.Id == id, false);

        //    if (villa == null)
        //    {
        //        return NotFound();
        //    }

        //    //moramo kreirati dto za patch
        //    VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);

        //    patchDto.ApplyTo(villaDto, ModelState);
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    villa = _mapper.Map<Villa>(villaDto);
        //    villa.UpdatedDate = DateTime.Now;

        //    await _dbVilla.Update(villa);
        //    return NoContent();
        //}

        #endregion

    }
}
