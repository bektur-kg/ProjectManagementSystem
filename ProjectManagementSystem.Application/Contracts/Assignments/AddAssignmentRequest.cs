using ProjectManagementSystem.Domain.Modules.Assignments;

namespace ProjectManagementSystem.Application.Contracts.Assignments;

public record AddAssignmentRequest
{
    public required string Title { get; set; }
    public required long ExecutorId { get; set; }
    public AssignmentPriority Priority { get; set; }
    public AssignmentStatus Status { get; set; }
}

