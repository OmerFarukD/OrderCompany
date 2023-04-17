using OrderCompany.Application.Features.Carrier.Dtos;
using OrderCompany.Application.Features.Carrier.Models;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Application.Features.Carrier.Profile;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Carrier, CarrierAddDto>().ReverseMap();
        CreateMap<Domain.Entities.Carrier, CarrierUpdateDto>().ReverseMap();
        CreateMap<Domain.Entities.Carrier, CarrierListDto>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Carrier>, CarrierListModel>().ReverseMap();
    }
}