using Demo.Models;
using System.Threading.Tasks;

namespace Demo.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> Update(Villa entity);
    }
}
