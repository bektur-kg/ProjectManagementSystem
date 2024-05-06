using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Features.Users.Login;

public class LoginCommandHandler(IUserRepository repository, IJwtProvider jwtProvider) 
    : ICommandHandler<LoginCommand, DataResult<string>>
{
    public async Task<DataResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserByEmailAsync(request.Data.Email);

        if (user is null) return DataResult<string>.Failure(UserErrors.UserNotFound);

        var token = jwtProvider.Generate(user);

        return DataResult<string>.Success(token);
    }
}

