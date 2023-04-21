namespace OrderCompany.Application.Features.Order.Dtos;

public record OrderResponseDto
{
    public int CarrierId { get; init; }
    public string? CarrierName { get; set; }
    public int OrderDesi { get; init; }
    public int CarrierMinDesi { get; init; }
    public  int CarrierMaxDesi { get; init; }
    public decimal OrderDesiCost { get; init; }
    public decimal OrderCarrierCost{ get; init; }
}
