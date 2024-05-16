using Microsoft.AspNetCore.Http;
using ProjectManagementSystem.Application.Abstractions;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Abstractions;
using ProjectManagementSystem.Domain.Modules.Comments;
using System.Security.Claims;

namespace ProjectManagementSystem.Application.Features.Comments.Update;

public class UpdateCommentCommandHandler 
    (
        IHttpContextAccessor httpContextAccessor,
        ICommentRepository commentRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<UpdateCommentCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdWithIncludeAsync(request.CommentId, includeAuthor: true);

        if (comment is null) return Result.Failure(CommentErrors.CommentNotFound);

        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var isUserCommentAuthor = comment.Author?.Id == userId;

        if (!isUserCommentAuthor) return Result.Failure(CommentErrors.NotCommentAuthor);

        comment.Content = request.Data.Content;
        _commentRepository.Update(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(); 
    }
}

