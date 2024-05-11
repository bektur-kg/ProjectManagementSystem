using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.Create;

public record CreateProjectCommand(CreateProjectRequest Data) : ICommand<DataResult<ProjectCreateResponse>>;