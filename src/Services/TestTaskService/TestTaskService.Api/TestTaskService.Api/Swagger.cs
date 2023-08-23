using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TestTaskService.Api;

internal static class Swagger
{
    public static string AppName { get; set; } = typeof(Swagger).Assembly.GetName().Name ?? "";

    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            options.SupportNonNullableReferenceTypes();
            options.CustomSchemaIds(type => type.FullName?.Replace("+", "_"));
            options.SwaggerDoc("v1", new OpenApiInfo { Title = AppName, Version = "v1" });
            options.AddFluentValidationRulesScoped();
            options.SchemaFilter<RequiredNotNullableSchemaFilter>();
            options.UseAllOfToExtendReferenceSchemas();
            options.UseAllOfForInheritance();
        });

        return services;
    }

    public static void UseCustomSwagger(this WebApplication app, string pathBase = "")
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"{pathBase}/swagger/v1/swagger.json", $"{AppName} v1");
        });
    }

    private class RequiredNotNullableSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            var additionalRequiredProps = model.Properties
                .Where(x => !x.Value.Nullable && !model.Required.Contains(x.Key))
                .Select(x => x.Key);
            foreach (var propKey in additionalRequiredProps)
            {
                model.Required.Add(propKey);
            }
        }
    }
}