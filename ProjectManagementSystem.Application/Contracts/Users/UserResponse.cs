using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Contracts.Users;

public record UserResponse
{
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string FatherName { get; set; }
    public required string Email { get; set; }
    public required UserRole Role { get; set; }
}

