using System.Linq.Expressions;
using OrderCompany.Application.Features.Carrier.Dtos;
using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Repositories;

namespace OrderCompany.Application.Services.Repositories;

public interface ICarrierRepository : IAsyncRepository<Carrier>, IRepository<Carrier>
{

}