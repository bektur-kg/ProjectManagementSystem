using AutoMapper;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Projects;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Features.Projects.Create;

public class CreateProjectCommandHandler
    (
        IMapper mapper,
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateProjectCommand, DataResult<ProjectCreateResponse>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<DataResult<ProjectCreateResponse>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var newProject = _mapper.Map<Project>(request.Data);
        newProject.StartedAt = DateTime.UtcNow;

        _projectRepository.Add(newProject);
        await _unitOfWork.SaveChangesAsync();

        var response = new ProjectCreateResponse { Id = newProject.Id };

        return DataResult<ProjectCreateResponse>.Success(response);
    }
}

