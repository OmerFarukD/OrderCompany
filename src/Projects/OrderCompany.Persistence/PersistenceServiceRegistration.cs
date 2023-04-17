
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Persistence.Contexts;
using OrderCompany.Persistence.Repositories;

namespace OrderCompany.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICarrierConfigurationRepository, CarrierConfigurationRepository>();
            services.AddScoped<ICarrierRepository, CarrierRepository>();
            
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            return services;
        }
    }
}
