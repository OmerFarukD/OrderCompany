using OrderCompany.Application.Services.Repositories;
using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Contexts;

namespace OrderCompany.Persistence.Repositories;

public class CarrierConfigurationRepository: EfRepositoryBase<CarrierConfiguration,AppDbContext>,ICarrierConfigurationRepository
{
    public CarrierConfigurationRepository(AppDbContext context) : base(context)
    {
    }
}