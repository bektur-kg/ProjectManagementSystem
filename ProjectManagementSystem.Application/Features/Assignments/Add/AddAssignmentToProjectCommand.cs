using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Assignments;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Assignments.Add;

public record AddAssignmentToProjectCommand(long ProjectId, AddAssignmentRequest Data) : ICommand<Result>;

