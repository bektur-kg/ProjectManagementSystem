using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Features.Projects.Delete;

public class DeleteProjectCommandHandler
    (
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<DeleteProjectCommand, Result>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.ProjectId);

        if (project is null) return Result.Failure(ProjectErrors.ProjectNotFound);

        _projectRepository.Remove(project);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

