using OrderCompany.Application.Services.Repositories;
using OrderCompany.Domain.Entities;
using OrderCompany.Persistence.Contexts;

namespace OrderCompany.Persistence.Repositories;

public class OrderRepository : EfRepositoryBase<Order,AppDbContext> , IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
    
}