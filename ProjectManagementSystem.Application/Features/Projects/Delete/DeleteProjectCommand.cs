using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.Delete;

public record DeleteProjectCommand(long ProjectId) : ICommand<Result>;

