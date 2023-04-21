using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.CarrierConfiguration.Models;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;
using OrderCompany.Shared.Requests;

namespace OrderCompany.Application.Features.CarrierConfiguration.Queries;

public static class CarrierConfigurationList
{
    public record Query(PageRequest PageRequest) : IRequest<Response<CarrierConfigurationListModel>>;
    
    public class Handler : IRequestHandler<Query,Response<CarrierConfigurationListModel>>
    {
        private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
        private readonly IMapper _mapper;

        public Handler(ICarrierConfigurationRepository carrierConfigurationRepository, IMapper mapper)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;
            _mapper = mapper;
        }

        public async Task<Response<CarrierConfigurationListModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            var data = await _carrierConfigurationRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize, cancellationToken:cancellationToken);

            CarrierConfigurationListModel configurationListModel = _mapper.Map<CarrierConfigurationListModel>(data);
            
            return Response<CarrierConfigurationListModel>.Success(configurationListModel,"Carrier Configuration Listed.",200);
        }
    }
}