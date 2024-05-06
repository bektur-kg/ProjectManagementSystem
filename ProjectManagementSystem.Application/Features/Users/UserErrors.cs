using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Users;

public abstract class UserErrors
{
    public static Error UserAlreadyExists = new("User.AlreadyExists", "Such user is already exists");
    public static Error UserNotFound = new("User.UserNotFound", "Such user is not found");
}

