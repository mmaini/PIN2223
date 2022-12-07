using System.Threading.Tasks;
using VillaAPI.Models;

namespace VillaAPI.Repository.IRepostiory
{
    public interface IVillaRepository : IRepository<Villa>
    {    
        Task<Villa> UpdateAsync(Villa entity); 
    }
}
