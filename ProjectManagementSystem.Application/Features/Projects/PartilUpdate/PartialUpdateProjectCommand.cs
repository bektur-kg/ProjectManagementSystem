using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.PartilUpdate;

public record PartialUpdateProjectCommand(long projectId, PartialChangeProjectRequest Data) : ICommand<Result>;