using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Assignments;

namespace ProjectManagementSystem.Application.Features.Assignments.Delete;

public class DeleteAssignmentCommandHandler 
    (
        IAssignmentRepository assignmentRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<DeleteAssignmentCommand, Result>
{
    private readonly IAssignmentRepository _assignmentRepository = assignmentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(request.AssignmentId);
        if (assignment is null) return Result.Failure(AssignmentErrors.AssignmentNotFound);

        _assignmentRepository.Remove(assignment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

