using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Features.Users.Login;

public class LoginCommandHandler
    (
        IUserRepository repository,
        IJwtProvider jwtProvider,
        IPasswordManager passwordManager
    ) 
    : ICommandHandler<LoginCommand, DataResult<string>>
{
    private readonly IUserRepository _repository = repository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IPasswordManager _passwordManager = passwordManager;

    public async Task<DataResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByEmailAsync(request.Data.Email);

        if (user is null) return DataResult<string>.Failure(UserErrors.UserNotFound);

        if (!_passwordManager.Verify(request.Data.Password, user.PasswordHash))
            return DataResult<string>.Failure(UserErrors.IncorrectPassword);

        var token = _jwtProvider.Generate(user);

        return DataResult<string>.Success(token);
    }
}

