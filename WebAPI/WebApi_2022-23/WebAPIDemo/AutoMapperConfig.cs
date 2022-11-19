using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Dto;

namespace WebAPIDemo
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<Villa, VillaCreateDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
        }
    }
}
