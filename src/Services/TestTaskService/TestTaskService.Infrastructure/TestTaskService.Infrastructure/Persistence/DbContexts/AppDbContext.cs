using Microsoft.EntityFrameworkCore;
using TestTaskService.Domain.Domain.Advertisements;
using TestTaskService.Domain.Domain.Users;

namespace TestTaskService.Infrastructure.Persistence.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Advertisement> Advertisements { get; set; } = null!;
}