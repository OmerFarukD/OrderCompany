using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderCompany.Application.Features.Carrier.Rules;
using OrderCompany.Application.Features.CarrierConfiguration.Rules;
using OrderCompany.Application.Features.Order.Rules;
using OrderCompany.Application.Pipelines.Validation;
using OrderCompany.Application.Services.OrderReportService;


namespace OrderCompany.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this  IServiceCollection services)
        {

            services.AddScoped<CarrierBusinessRules>();
            services.AddScoped<CarrierConfigurationRules>();
            services.AddScoped<OrderBusinessRule>();
            services.AddScoped<IOrderReportService, OrderReportService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
