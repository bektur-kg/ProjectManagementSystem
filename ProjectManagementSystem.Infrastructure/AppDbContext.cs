using Microsoft.EntityFrameworkCore;

namespace ProjectManagementSystem.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}

