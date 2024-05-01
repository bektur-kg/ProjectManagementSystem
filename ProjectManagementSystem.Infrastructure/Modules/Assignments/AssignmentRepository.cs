using ProjectManagementSystem.Domain.Modules.Assignments;

namespace ProjectManagementSystem.Infrastructure.Modules.Assignments;

public class AssignmentRepository(AppDbContext dbContext) : Repository<Assignment>(dbContext), IAssignmentRepository;

