using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Assignments;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Assignments.GetByProjectId;

public record GetProjectAssignmentsQuery(long ProjectId) : IQuery<DataResult<List<AssignmentResponse>>>;

