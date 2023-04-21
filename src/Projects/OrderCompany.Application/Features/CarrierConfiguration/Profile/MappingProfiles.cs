using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Application.Features.CarrierConfiguration.Models;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Application.Features.CarrierConfiguration.Profile;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.CarrierConfiguration, CarrierConfigurationListDto>().ReverseMap();
        CreateMap<Domain.Entities.CarrierConfiguration, CarrierConfigurationAddDto>().ReverseMap();
        CreateMap<Domain.Entities.CarrierConfiguration, CarrierConfigurationUpdateDto>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.CarrierConfiguration>, CarrierConfigurationListModel>().ReverseMap();
    }
}