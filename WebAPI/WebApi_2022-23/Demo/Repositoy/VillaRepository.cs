using Demo.Data;
using Demo.Models;
using Demo.Repository.IRepository;
using System;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly AppDbContext _db;
        public VillaRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Villa> Update(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
