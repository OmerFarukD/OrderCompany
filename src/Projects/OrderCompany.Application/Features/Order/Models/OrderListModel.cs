using OrderCompany.Application.Features.Order.Dtos;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Application.Features.Order.Models;

public class OrderListModel : BasePageableModel
{
    public List<OrderListDto> Items { get; set; } = new List<OrderListDto>();
}