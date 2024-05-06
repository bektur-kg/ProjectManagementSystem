using ProjectManagementSystem.Domain.Modules.Projects;
using ProjectManagementSystem.Infrastructure.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Projects;

public class ProjectRepository(AppDbContext dbContext) : Repository<Project>(dbContext), IProjectRepository;
