using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.AddEmployee;

public record AddEmployeeToProjectComand(long ProjectId, long EmployeeId) : ICommand<Result>;

