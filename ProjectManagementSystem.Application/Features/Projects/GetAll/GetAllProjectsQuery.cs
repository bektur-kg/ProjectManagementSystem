using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Project;

namespace ProjectManagementSystem.Application.Features.Projects.GetAll;

public class GetAllProjectsQuery : IQuery<List<ProjectResponse>>;

