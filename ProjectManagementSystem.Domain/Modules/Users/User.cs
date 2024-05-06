using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Domain.Modules.Users;

public class User : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string FatherName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Email { get; set; }
    public required UserRole Role { get; set; }
}

