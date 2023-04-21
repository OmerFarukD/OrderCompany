using AutoMapper;
using OrderCompany.Application.Features.Order.Dtos;
using OrderCompany.Application.Features.Order.Models;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Application.Features.Order.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Order, OrderAddDto>().ReverseMap();
        CreateMap<Domain.Entities.Order, OrderListDto>().ReverseMap();
        CreateMap<Domain.Entities.Order, OrderUpdateDto>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Order>, OrderListModel>().ReverseMap();
    }
}