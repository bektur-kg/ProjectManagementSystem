using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Modules.Users;
using ProjectManagementSystem.Infrastructure.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Users;

public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
    public Task<User?> GetUserByEmailAsync(string email) => DbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
}

