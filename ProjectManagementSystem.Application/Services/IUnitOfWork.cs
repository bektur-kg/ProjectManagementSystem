namespace ProjectManagementSystem.Application.Services;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync();
}
