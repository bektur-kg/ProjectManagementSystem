using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Assignments.Delete;

public record DeleteAssignmentCommand(long AssignmentId) : ICommand<Result>;

