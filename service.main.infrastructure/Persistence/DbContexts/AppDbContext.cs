using Microsoft.EntityFrameworkCore;
using service.main.domain.Advertisements;
using service.main.domain.Users;

namespace service.main.infrastructure.Persistence.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Advertisement> Advertisements { get; set; } = null!;
}