using OrderCompany.Application.Services.Repositories;
using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Contexts;

namespace OrderCompany.Persistence.Repositories;

public class CarrierRepository : EfRepositoryBase<Carrier,AppDbContext>, ICarrierRepository
{
    public CarrierRepository(AppDbContext context) : base(context)
    {
    }
}