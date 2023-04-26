using Microsoft.EntityFrameworkCore;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Domain.Entities;

namespace OrderCompany.Application.Services.OrderReportService;

public class OrderReportService : IOrderReportService
{
    private readonly ICarrierReportRepository _carrierReportRepository;

    public OrderReportService(ICarrierReportRepository carrierReportRepository)
    {
        _carrierReportRepository = carrierReportRepository;
    }
    public async  Task AddOrderReports()
    {
        await _carrierReportRepository.AddReports();
    }
}