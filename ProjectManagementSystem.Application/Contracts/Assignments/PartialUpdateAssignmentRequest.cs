using ProjectManagementSystem.Domain.Modules.Assignments;

namespace ProjectManagementSystem.Application.Contracts.Assignments;

public record PartialUpdateAssignmentRequest
{
    public string? Title { get; set; }
    public long? ExecutorId { get; set; }
    public AssignmentPriority? Priority { get; set; }
    public AssignmentStatus? Status { get; set; }
}

