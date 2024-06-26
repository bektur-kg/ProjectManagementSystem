﻿
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Users;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Users.Login;

public record LoginCommand(UserLoginRequest Data) : ICommand<DataResult<string>>;

