using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Services;
public interface IJwtProvider
{
    string Generate(User user);
}
