using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Modules.Assignments;

namespace ProjectManagementSystem.Infrastructure.Modules.Assignments;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder
            .HasOne(a => a.Author)
            .WithMany()
            .HasForeignKey(a => a.AuthorId);

        builder
            .HasOne(a => a.Executor)
            .WithMany()
            .HasForeignKey(a => a.ExecutorId);

        builder
            .HasOne(a => a.Project)
            .WithMany(p => p.Assignments)
            .HasForeignKey(a => a.ProjectId);

        builder
            .HasMany(a => a.Comments)
            .WithOne(c => c.Assignment)
            .HasForeignKey(c => c.AssignmentId);
    }
}

