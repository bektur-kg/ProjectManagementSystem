using ProjectManagementSystem.Application.Services;

namespace ProjectManagementSystem.Infrastructure;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}

