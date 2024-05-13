using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.RemoveEmployee;

public record RemoveEmployeeFromProjectCommand(long ProjectId, long EmployeeId) : ICommand<Result>;

