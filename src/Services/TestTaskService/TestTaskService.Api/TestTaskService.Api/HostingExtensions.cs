using System.Text.Json.Serialization;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using TestTaskService.Api.Middlewares;
using TestTaskService.Application;
using TestTaskService.Infrastructure;

namespace TestTaskService.Api;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
        {
            var enumConverter = new JsonStringEnumConverter(allowIntegerValues: false);
            options.JsonSerializerOptions.Converters.Add(enumConverter);
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCustomSwagger();

        builder.Services.AddFluentValidationRulesToSwagger();

        builder.Services.RegisterApplicationLayer();
        builder.Services.RegisterInfrastructureLayer(builder.Configuration);
        
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCustomSwagger();
        }

        app.UseCors(opt =>
        {
            opt.AllowAnyHeader();
            opt.AllowAnyOrigin();
            opt.AllowAnyMethod();
        });

        app.UseMiddleware<GlobalErrorHandlingMiddleware>();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}