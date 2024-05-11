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
    private readonly IUserRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPasswordManager _passwordManager = passwordManager;

    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Data.Role == UserRole.Leader) return Result.Failure(UserErrors.CannotCreateLeader);

        var foundUser = await _repository.GetUserByEmailAsync(request.Data.Email);

        if (foundUser is not null) return Result.Failure(UserErrors.UserAlreadyExists);

        var hashedPassword = _passwordManager.Hash(request.Data.Password);

        var mappedUser = _mapper.Map<User>(request.Data);
        mappedUser.PasswordHash = hashedPassword;

        _repository.Add(mappedUser);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

