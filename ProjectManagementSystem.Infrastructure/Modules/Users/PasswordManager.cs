using ProjectManagementSystem.Application.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Users;

public class PasswordManager : IPasswordManager
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
}