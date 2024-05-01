namespace ProjectManagementSystem.Domain.Abstractions;

public interface IWriteRepository<TEntity> where TEntity : Entity
{
    Task AddAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}
