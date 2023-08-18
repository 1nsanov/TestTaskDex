using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using service.main.domain.Repositories;
using service.main.infrastructure.Persistence.DbContexts;
using service.main.infrastructure.Persistence.Repositories;

namespace service.main.infrastructure;

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