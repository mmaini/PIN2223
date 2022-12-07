using Demo.Data;
using Demo.Models;
using Demo.Repository;
using Demo.Repository.IRepository;
using System;
using System.Threading.Tasks;


namespace Demo.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly AppDbContext _db;
        public VillaNumberRepository(AppDbContext db) : base(db)
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
