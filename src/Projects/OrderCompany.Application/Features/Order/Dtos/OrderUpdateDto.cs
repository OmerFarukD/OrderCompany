namespace OrderCompany.Application.Features.Order.Dtos;

public sealed record OrderUpdateDto(int Id, int CarrierId, int OrderDesi, DateTime OrderTime, decimal OrderCarrierCost);