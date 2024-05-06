using AutoMapper;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Features.Users.Register;

public class RegisterUserCommandHandler
    (
        IUserRepository repository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPasswordManager passwordManager
    ) : ICommandHandler<RegisterUserCommand, Result>
{
    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await repository.GetUserByEmailAsync(request.Data.Email);

        if (foundUser is not null) return Result.Failure(UserErrors.UserAlreadyExists);

        var hashedPassword = passwordManager.Hash(request.Data.Password);

        var mappedUser = mapper.Map<User>(request.Data);
        mappedUser.PasswordHash = hashedPassword;

        repository.Add(mappedUser);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

