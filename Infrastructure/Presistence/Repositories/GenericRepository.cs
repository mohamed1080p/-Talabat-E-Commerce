

using Domain.Contracts;
using Presistence.Data;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    internal class GenericRepository<TEntity, TKey>(StoreDbContext _dbContext) : IGenericRepository<TEntity, TKey> where TEntity:BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false)
        {
            if(asNoTracking==false)
            {
                return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            else
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity?> GetByIdAsync(TKey Id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(Id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
