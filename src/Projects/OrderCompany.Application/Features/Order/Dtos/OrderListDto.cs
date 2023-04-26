namespace OrderCompany.Application.Features.Order.Dtos;
public sealed class OrderListDto
{
    public int Id { get; set; }
    public int CarrierId { get; set; }
    public string? CarrierName { get; set; }
    public int OrderDesi { get; set; }
    public DateTime OrderTime { get; set; }
    
}