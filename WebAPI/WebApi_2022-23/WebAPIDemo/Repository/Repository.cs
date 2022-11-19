using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPIDemo.Data;
using WebAPIDemo.Repository.IRepository;

namespace WebAPIDemo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbset = _db.Set<T>();
        }

        public async Task Create(T entity)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        {
            await _dbset.AddAsync(entity);
            await Save();
        }

        public async Task Remove(T entity)
        {
            _dbset.Remove(entity);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbset;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
