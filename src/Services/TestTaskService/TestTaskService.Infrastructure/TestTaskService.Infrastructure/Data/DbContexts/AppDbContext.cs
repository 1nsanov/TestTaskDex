using Microsoft.EntityFrameworkCore;
using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Entities.Users;
using TestTaskService.Infrastructure.Data.Configuration;

namespace TestTaskService.Infrastructure.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Advertisement> Advertisements { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
    }
}