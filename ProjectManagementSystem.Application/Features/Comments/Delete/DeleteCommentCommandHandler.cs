using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Comments;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Comments.Delete;

public class DeleteCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<DeleteCommentCommand, Result>
{
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdWithIncludeAsync(request.CommentId, includeAuthor: true);

        if (comment is null) return Result.Failure(CommentErrors.CommentNotFound);

        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var isUserCommentAuthor = comment.Author?.Id == userId;

        if (!isUserCommentAuthor) return Result.Failure(CommentErrors.NotCommentAuthor);

        _commentRepository.Remove(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

