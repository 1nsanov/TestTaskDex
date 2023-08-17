using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using service.main.application.Common;
using service.main.infrastructure;

namespace service.main;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SupportNonNullableReferenceTypes();
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "task.service.main", Version = "v1" });
        });

        builder.Services.AddFluentValidationRulesToSwagger();

        builder.Services.RegisterApplicationLayer();
        builder.Services.RegisterInfrastructureLayer(builder.Configuration);
        
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(opt =>
        {
            opt.AllowAnyHeader();
            opt.AllowAnyOrigin();
            opt.AllowAnyMethod();
        });

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}