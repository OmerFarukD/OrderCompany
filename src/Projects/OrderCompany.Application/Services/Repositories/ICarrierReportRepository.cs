using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Repositories;

namespace OrderCompany.Application.Services.Repositories;

public interface ICarrierReportRepository : IAsyncRepository<CarrierReport>,IRepository<CarrierReport>
{
    Task AddReports();
}