using Microsoft.EntityFrameworkCore;
using OrderCompany.Application.Services.OrderReportService;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Contexts;

namespace OrderCompany.Persistence.Repositories;

public class CarrierReportRepository : EfRepositoryBase<CarrierReport,AppDbContext>,ICarrierReportRepository
{
    public CarrierReportRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddReports()
    {
        using (var dbContextTransaction = await Context.Database.BeginTransactionAsync())
        {
            try
            {
                var orders =await Context.Orders.GroupBy(o => new { o.CarrierId, o.OrderTime })
                    .Select(g => new
                    {
                        CarrierId = g.Key.CarrierId,
                        CarrierCost = g.Sum(x => x.OrderCarrierCost),
                        OrderTime = g.Key.OrderTime
                    }).ToListAsync();
                foreach (var order in orders)
                {
                    var existingReport = await Context.CarrierReports
                        .Where(c => c.CarrierId.Equals(order.CarrierId) && c.CarrierReportDate.Equals(order.OrderTime))
                        .FirstOrDefaultAsync();

                    if (existingReport is not null)
                    {
                        existingReport.CarrierCost += order.CarrierCost;
                    }
                    else
                    {
                        var newReport = new CarrierReport()
                        {
                            CarrierId = order.CarrierId,
                            CarrierCost = order.CarrierCost,
                            CarrierReportDate = order.OrderTime
                        };
                        Context.Add(newReport);
                    }
                }

                await Context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
            }
            catch (Exception e)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }
    }
    
}