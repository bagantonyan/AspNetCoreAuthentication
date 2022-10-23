using AspNetCoreAuthentication.DAL.Contexts;
using AspNetCoreAuthentication.DAL.Entities.Abstractions;
using AspNetCoreAuthentication.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAuthentication.DAL.Repositories.Implementations
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AuthenticationDbContext dbContext) => _dbSet = dbContext.Set<TEntity>();

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task<TEntity> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }
}
