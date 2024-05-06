using ProjectManagementSystem.Application.Constants;
using ProjectManagementSystem.Domain.Modules.Users;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.Application.Contracts.User;

public record UserCreateRequest
{
    [MaxLength(AttributeConstants.FIRST_NAME_MAX_LENGTH)]
    public required string FirstName { get; set; }

    [MaxLength(AttributeConstants.LAST_NAME_MAX_LENGTH)]
    public required string LastName { get; set; }

    [MaxLength(AttributeConstants.FATHER_NAME_MAX_LENGTH)]
    public required string FatherName { get; set; }

    [PasswordPropertyText]
    public required string Password { get; set; }

    [EmailAddress]
    public required string Email { get; set; }
    public required UserRole Role { get; set; }
}

