using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPIDemo.Data;
using WebAPIDemo.Models;
using WebAPIDemo.Repository.IRepository;

namespace WebAPIDemo.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<VillaNumber> Update(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
