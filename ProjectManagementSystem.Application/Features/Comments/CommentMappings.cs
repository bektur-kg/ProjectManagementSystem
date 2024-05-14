using AutoMapper;
using ProjectManagementSystem.Application.Contracts.Comments;
using ProjectManagementSystem.Domain.Modules.Comments;

namespace ProjectManagementSystem.Application.Features.Comments;

public class CommentMappings : Profile
{
    public CommentMappings()
    {
        CreateMap<Comment, CommentResponse>();
    }
}

