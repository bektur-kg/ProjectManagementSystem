﻿using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Infrastructure.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Comments;

public class CommentRepository(AppDbContext dbContext) : Repository<Comment>(dbContext), ICommentRepository;

