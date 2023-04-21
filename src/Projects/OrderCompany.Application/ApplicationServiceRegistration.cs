using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderCompany.Application.Features.Carrier.Rules;
using OrderCompany.Application.Features.CarrierConfiguration.Rules;
using OrderCompany.Application.Features.Order.Rules;
using OrderCompany.Application.Pipelines.Validation;

namespace OrderCompany.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this  IServiceCollection services)
        {

            services.AddScoped<CarrierBusinessRules>();
            services.AddScoped<CarrierConfigurationRules>();
            services.AddScoped<OrderBusinessRule>();
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
