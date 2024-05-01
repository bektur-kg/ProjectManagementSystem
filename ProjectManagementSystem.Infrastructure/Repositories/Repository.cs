using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Infrastructure.Repositories;

public class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    public Task AddAsync(TEntity entity)
    {
        dbContext.Set<TEntity>().Add(entity);
    }
   

    public Task<List<TEntity>> GetAllAsync()
    {
    }

    public Task<TEntity?> GetByIdAsync(long id)
    {
    }

    public Task RemoveAsync(TEntity entity)
    {
    }
}

