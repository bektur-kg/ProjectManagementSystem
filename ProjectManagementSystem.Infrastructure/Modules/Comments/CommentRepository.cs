using ProjectManagementSystem.Domain.Modules.Comments;

namespace ProjectManagementSystem.Infrastructure.Modules.Comments;

public class CommentRepository(AppDbContext dbContext) : Repository<Comment>(dbContext), ICommentRepository;

