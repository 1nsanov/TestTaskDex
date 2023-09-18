using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTaskService.Application.Interfaces.Repositories;
using TestTaskService.Infrastructure.Data.DbContexts;
using TestTaskService.Infrastructure.Repositories;

namespace TestTaskService.Infrastructure;

public static class DependencyInjection
{
    public static void RegisterInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContextPool<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
    }
}