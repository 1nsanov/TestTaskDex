using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestTaskService.Application.Behaviours;
using TestTaskService.Application.Commands.Users.UserAdd;
using TestTaskService.Application.Commands.Users.UserUpdate;

namespace TestTaskService.Application;

public static class DependencyInjection
{
    public static void RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        
        services.AddAutoMapper(typeof(DependencyInjection));
        
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection), includeInternalTypes: true);
        services.AddFluentValidationAutoValidation();
        services.AddValidators();
       
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
    
    private static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserAddCommand>, UserAddCommandValidator>();
        services.AddScoped<IValidator<UserUpdateCommand>, UserUpdateCommandValidator>();
    }
}