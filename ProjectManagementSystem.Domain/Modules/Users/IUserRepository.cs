﻿using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Domain.Modules.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}
