using Microsoft.EntityFrameworkCore;
using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Infrastructure.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Advertisement> Advertisements { get; set; } = null!;
}