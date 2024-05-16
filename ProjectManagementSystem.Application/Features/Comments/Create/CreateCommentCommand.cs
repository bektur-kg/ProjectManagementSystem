using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Comments;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Comments.Create;

public record CreateCommentCommand(long AssignmentId, long ProjectId, CommentCreateRequest Data) : ICommand<Result>;

