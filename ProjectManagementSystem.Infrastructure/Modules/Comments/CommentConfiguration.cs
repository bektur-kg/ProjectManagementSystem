using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Modules.Comments;

namespace ProjectManagementSystem.Infrastructure.Modules.Comments;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasOne(c => c.Author)
            .WithMany()
            .HasForeignKey(c => c.AuthorId);

        builder
            .HasOne(c => c.Assignment)
            .WithMany(a => a.Comments)
            .HasForeignKey(c => c.AssignmentId);
    }
}

