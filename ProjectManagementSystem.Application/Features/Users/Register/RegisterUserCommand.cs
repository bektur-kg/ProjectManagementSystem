using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.User;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Users.Register;

public record RegisterUserCommand(UserCreateRequest Data) : ICommand<Result>;

