using Microsoft.EntityFrameworkCore;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.CrossCuttingConcerns.Exceptions;
using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Contexts;

namespace OrderCompany.Persistence.Repositories;

public class CarrierConfigurationRepository: EfRepositoryBase<CarrierConfiguration,AppDbContext>,ICarrierConfigurationRepository
{
    public CarrierConfigurationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task CarrierConfigurationUpdateForCarrier(int configId, int carrierId)
    {
        var conf = await Context.CarrierConfigurations.Where(x => x.Id.Equals(configId)).FirstOrDefaultAsync();
        
        conf.CarrierId = carrierId;

        await Context.SaveChangesAsync();
    }
}