using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Domain.Modules.Comments;
using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Domain.Modules.Users;
using ProjectManagementSystem.Infrastructure.Modules.Assignments;
using ProjectManagementSystem.Infrastructure.Modules.Comments;
using ProjectManagementSystem.Infrastructure.Modules.Projects;
using ProjectManagementSystem.Infrastructure.Modules.Users;

namespace ProjectManagementSystem.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<AppDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(nameof(AppDbContext)));
        });
    }
}

