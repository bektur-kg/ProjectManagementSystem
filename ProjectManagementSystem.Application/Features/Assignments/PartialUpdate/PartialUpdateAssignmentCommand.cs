using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Assignments;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Assignments.PartialUpdate;

public record PartialUpdateAssignmentCommand(long AssignmentId, long ProjectId, PartialUpdateAssignmentRequest Data) : ICommand<Result>;