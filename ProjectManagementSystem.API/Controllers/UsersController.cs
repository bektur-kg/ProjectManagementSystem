﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Contracts.User;
using ProjectManagementSystem.Application.Features.Users.Login;
using ProjectManagementSystem.Application.Features.Users.Register;

namespace ProjectManagementSystem.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(UserCreateRequest dto)
    {
        var request = new RegisterUserCommand(dto);

        var response = await sender.Send(request);
        
        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginRequest dto)
    {
        var request = new LoginCommand(dto);

        var response = await sender.Send(request);

        return response.IsSuccess ? Ok(response.Data) : BadRequest(response.Error); 
    }
}
