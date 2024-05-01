﻿namespace ProjectManagementSystem.Domain.Abstractions;

public interface IWriteRepository<TEntity> where TEntity : Entity
{
    void Add(TEntity entity);
    void Remove(TEntity entity);
}
