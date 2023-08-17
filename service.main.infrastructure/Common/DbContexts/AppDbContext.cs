using Microsoft.EntityFrameworkCore;

namespace service.main.infrastructure.Common.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}