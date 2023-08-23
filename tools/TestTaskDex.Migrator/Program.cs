using Microsoft.EntityFrameworkCore;

namespace TestTaskDex.Migrator;

class Program
{
    static void Main(string[] args)
    {
        var dbContextFactory = new DbContextFactory();
        using var context = dbContextFactory.CreateDbContext(args);
        context.Database.Migrate();
        Console.WriteLine("Database migration completed successfully.");
    }
}