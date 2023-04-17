using OrderCompany.Application.Features.Carrier.Dtos;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Application.Features.Carrier.Models;

public class CarrierListModel : BasePageableModel
{
    public List<CarrierListDto> Items { get; set; } = new List<CarrierListDto>();
}