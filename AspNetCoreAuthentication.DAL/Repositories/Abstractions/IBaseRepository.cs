using AspNetCoreAuthentication.DAL.Entities.Abstractions;

namespace AspNetCoreAuthentication.DAL.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
    }
}
