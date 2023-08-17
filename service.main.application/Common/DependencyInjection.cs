﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using service.main.application.Common.Validation;

namespace service.main.application.Common;

public static class DependencyInjection
{
    public static void RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        services.AddAutoMapper(typeof(DependencyInjection));
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection), includeInternalTypes: true);
        services.AddFluentValidationAutoValidation();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
}