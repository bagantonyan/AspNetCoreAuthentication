using AspNetCoreAuthentication.DAL.Entities.Abstractions;

namespace AspNetCoreAuthentication.DAL.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(long id);
    }
}
