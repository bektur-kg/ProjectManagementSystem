using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Assignments;

public abstract class AssignmentErrors
{
    public static Error AssignmentNotFound = new("Assignment.AssignmentNotFound", "Assignment with such id not found");
    public static Error NotAccessible = new("Assignment.NotAccessible", "Assignments not accessible for this user");
}

