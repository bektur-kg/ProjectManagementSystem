using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Assignments;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Assignments.GetById;

public record GetAssignmentByIdQuery(long ProjectId, long AssignmentId) : IQuery<DataResult<AssignmentDetailedResponse>>;

