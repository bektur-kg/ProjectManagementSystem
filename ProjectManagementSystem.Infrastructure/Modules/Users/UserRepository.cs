using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Infrastructure.Modules.Users;

public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository;

