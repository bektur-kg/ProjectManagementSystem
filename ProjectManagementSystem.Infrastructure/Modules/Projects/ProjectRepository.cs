using ProjectManagementSystem.Domain.Modules.Projects;

namespace ProjectManagementSystem.Infrastructure.Modules.Projects;

public class ProjectRepository(AppDbContext dbContext) : Repository<Project>(dbContext), IProjectRepository;
