using Domain.Interfaces;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SafeMoneyContext _context;

        public BaseRepository(SafeMoneyContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<List<TEntity>> AddList(List<TEntity> obj)
        {
            await _context.Set<TEntity>().AddRangeAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }

        public virtual async Task Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
