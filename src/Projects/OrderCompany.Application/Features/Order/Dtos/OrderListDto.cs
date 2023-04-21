namespace OrderCompany.Application.Features.Order.Dtos;

public record OrderListDto(int Id, int CarrierId, int OrderDesi, DateTime OrderTime, decimal OrderCarrierCost);