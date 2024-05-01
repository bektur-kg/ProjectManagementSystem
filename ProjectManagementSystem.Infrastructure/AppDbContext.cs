using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;
using System.Reflection;

namespace ProjectManagementSystem.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Comment> Comments => Set<Comment>();   
    public DbSet<Assignment> Assignments => Set<Assignment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

