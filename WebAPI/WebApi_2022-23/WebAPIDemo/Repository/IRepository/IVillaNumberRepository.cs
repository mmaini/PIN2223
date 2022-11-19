using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> Update(VillaNumber entity);
    }
}
