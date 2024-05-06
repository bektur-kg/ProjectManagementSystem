using ProjectManagementSystem.Domain.Modules.Assignments;
using ProjectManagementSystem.Infrastructure.Services;

namespace ProjectManagementSystem.Infrastructure.Modules.Assignments;

public class AssignmentRepository(AppDbContext dbContext) : Repository<Assignment>(dbContext), IAssignmentRepository;

