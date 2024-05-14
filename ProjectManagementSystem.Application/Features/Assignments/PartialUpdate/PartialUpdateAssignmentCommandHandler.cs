using AutoMapper;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Features.Projects;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Application.Features.Assignments.PartialUpdate;

public class PartialUpdateAssignmentCommandHandler 
    (
        IAssignmentRepository assignmentRepository,
        IProjectRepository projectRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<PartialUpdateAssignmentCommand, Result>
{
    private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(PartialUpdateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentRepository.GetAssignmentByIdWithIncludeAndTrackingAsync(request.AssignmentId, includeExecutor: true);

        if (assignment is null) return Result.Failure(AssignmentErrors.AssignmentNotFound);

        var executor = (await _projectRepository.GetProjectByIdWithIncludeAsync(request.ProjectId, includeEmployees: true))
            ?.Employees.FirstOrDefault(employee => employee.Id == request.Data.ExecutorId);

        if (request.Data.ExecutorId > 0 && executor is null) return Result.Failure(ProjectErrors.EmployeeNotFoundInProject);

        _mapper.Map(request.Data, assignment);
        _assignmentRepository.Update(assignment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

