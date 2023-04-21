using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Application.Features.CarrierConfiguration.Models;

public class CarrierConfigurationListModel : BasePageableModel
{
    public List<CarrierConfigurationListDto> Items { get; set; } = new List<CarrierConfigurationListDto>();
}