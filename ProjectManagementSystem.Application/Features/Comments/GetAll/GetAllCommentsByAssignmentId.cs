using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Contracts.Comments;
using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Comments.GetAll;

public record GetAllCommentsByAssignmentId(long ProjectId, long AssignmentId) : IQuery<DataResult<List<CommentResponse>>>;