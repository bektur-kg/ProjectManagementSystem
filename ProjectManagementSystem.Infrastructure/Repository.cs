using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Infrastructure;

public abstract class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    public void Add(TEntity entity) => dbContext.Add(entity);

    public Task<List<TEntity>> GetAllAsync() => dbContext
        .Set<TEntity>()
        .AsNoTracking()
        .ToListAsync();

    public Task<TEntity?> GetByIdAsync(long id) => dbContext
        .Set<TEntity>()
        .AsNoTracking()
        .FirstOrDefaultAsync(entity => entity.Id == id);

    public void Remove(TEntity entity) => dbContext.Remove(entity);
}

