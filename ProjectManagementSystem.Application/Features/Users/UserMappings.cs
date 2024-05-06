using AutoMapper;
using ProjectManagementSystem.Application.Contracts.User;
using ProjectManagementSystem.Domain.Modules.Users;

namespace ProjectManagementSystem.Application.Features.Users;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<UserCreateRequest, User>();
    }
}

