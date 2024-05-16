using ProjectManagementSystem.Domain.Abstractions;

namespace ProjectManagementSystem.Application.Features.Comments;

public abstract class CommentErrors
{
    public static Error CommentNotFound = new("Comment.CommentNotFound", "Such comment is not found");
    public static Error NotCommentAuthor = new("Comment.NotCommentAuthor", "User is not an author of this comment");
}

