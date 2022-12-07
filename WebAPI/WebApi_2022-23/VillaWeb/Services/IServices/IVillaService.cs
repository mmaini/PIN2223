using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaWeb.Models.Dto;

namespace VillaWeb.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDto dto);
        Task<T> UpdateAsync<T>(VillaUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
