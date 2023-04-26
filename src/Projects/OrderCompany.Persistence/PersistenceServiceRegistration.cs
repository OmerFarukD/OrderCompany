
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Persistence.Contexts;
using OrderCompany.Persistence.Extensions;
using OrderCompany.Persistence.Repositories;

namespace OrderCompany.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            
            var storageOptions = new SqlServerStorageOptions
            {
                SchemaName = "hangfire"
            };
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICarrierConfigurationRepository, CarrierConfigurationRepository>();
            services.AddScoped<ICarrierRepository, CarrierRepository>();
            services.AddScoped<ICarrierReportRepository, CarrierReportRepository>();
            services.AddHangfire(opt => opt.UseSqlServerStorage(configuration.GetBackgroundJobString("HangfireCon"),storageOptions));
            
            
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            return services;
        }
    }
}
