using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.GetById;

public record GetProjectByIdQuery(long ProjectId) : IQuery<DataResult<ProjectDetailedResponse>>;

