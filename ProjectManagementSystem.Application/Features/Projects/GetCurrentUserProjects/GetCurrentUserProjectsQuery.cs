using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Projects.GetCurrentUserProjects;

public record GetCurrentUserProjectsQuery : IQuery<DataResult<List<ProjectResponse>>>;
