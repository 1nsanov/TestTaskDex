using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestTaskService.Application.Behaviours;
using TestTaskService.Application.Commands.Users.UserAdd;
using TestTaskService.Application.Commands.Users.UserUpdate;
using TestTaskService.Application.Mappings;

namespace TestTaskService.Application;

public static class DependencyInjection
{
    public static void RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        
        services.AddAutoMapper(typeof(UserProfile).Assembly);
        
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection), includeInternalTypes: true);
        services.AddFluentValidationAutoValidation();
        services.AddValidators();
       
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
    
    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserAddCommand>, UserAddCommandValidator>();
        services.AddScoped<IValidator<UserUpdateCommand>, UserUpdateCommandValidator>();

        return services;
    }
}