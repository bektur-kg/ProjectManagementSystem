using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Domain.Abstractions;
namespace ProjectManagementSystem.Application.Features.Comments.Delete;

public record DeleteCommentCommand(long CommentId) : ICommand<Result>; 

