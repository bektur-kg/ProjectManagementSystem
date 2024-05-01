using AutoMapper;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Project;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Features.Projects.GetAll;

public class GetAllProjectsQueryHandler(IProjectRepository repository, IMapper mapper) 
    : IQueryHandler<GetAllProjectsQuery, List<ProjectResponse>>
{
    public async Task<List<ProjectResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await repository.GetAllAsync();

        var mappedProjects = mapper.Map<List<ProjectResponse>>(projects);

        return mappedProjects;
    }
}

