﻿using ProjectManagementSystem.Application.Services;

namespace ProjectManagementSystem.Infrastructure.Services;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}

