
using Domain.Entities.ProductModule;

namespace Domain.Contracts
{
    internal interface IGenericRepository<TEntity,TKey> where TEntity:BaseEntity<TKey>
    {
        //Get All
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false);

        //Get By Id
        Task<TEntity?> GetByIdAsync(TKey Id);

        //Add
        Task AddAsync(TEntity entity);

        //Remove
        void Delete(TEntity entity);

        //Update
        void Update(TEntity entity);
    }
}
