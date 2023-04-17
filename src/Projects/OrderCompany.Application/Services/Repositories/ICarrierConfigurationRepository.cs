using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Repositories;

namespace OrderCompany.Application.Services.Repositories;

public interface ICarrierConfigurationRepository : IAsyncRepository<CarrierConfiguration>, IRepository<CarrierConfiguration>
{
}