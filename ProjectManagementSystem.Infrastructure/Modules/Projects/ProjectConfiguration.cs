using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Infrastructure.Modules.Projects;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .HasMany(p => p.Employees)
            .WithMany();

        builder
            .HasOne(p => p.Leader)
            .WithMany()
            .HasForeignKey(p => p.LeaderId);

        builder.
            HasMany(p => p.Assignments)
            .WithOne(a => a.Project)
            .HasForeignKey(a => a.ProjectId);
    }
}

