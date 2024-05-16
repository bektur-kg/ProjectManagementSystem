using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Comments;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Comments.Update;

public record UpdateCommentCommand(long CommentId, UpdateCommentRequest Data) : ICommand<Result>;

