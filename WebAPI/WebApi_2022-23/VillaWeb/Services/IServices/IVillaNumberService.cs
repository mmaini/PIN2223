

using System.Threading.Tasks;
using VillaWeb.Models.Dto;

namespace VillaWeb.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaNumberCreateDto dto);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
