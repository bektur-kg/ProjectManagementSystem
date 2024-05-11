using AutoMapper;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Features.Projects.GetAll;

public class GetAllProjectsQueryHandler(IProjectRepository repository, IMapper mapper) 
    : IQueryHandler<GetAllProjectsQuery, DataResult<List<ProjectResponse>>>
{
    private readonly IProjectRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<DataResult<List<ProjectResponse>>> Handle
        (GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAllAsync();

        var mappedProjects = _mapper.Map<List<ProjectResponse>>(projects);

        return DataResult<List<ProjectResponse>>.Success(mappedProjects);
    }
}

