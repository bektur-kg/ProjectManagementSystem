using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.Application.Contracts.User;

public record UserLoginRequest
{
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }
}

