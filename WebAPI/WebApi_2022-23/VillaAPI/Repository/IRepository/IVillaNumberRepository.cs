using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VillaAPI.Models;

namespace VillaAPI.Repository.IRepostiory
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
      
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
  
    }
}
