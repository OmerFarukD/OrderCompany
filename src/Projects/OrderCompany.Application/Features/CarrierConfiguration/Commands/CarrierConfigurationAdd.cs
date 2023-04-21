using System.Security.Cryptography;
using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.Carrier.Dtos;
using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.CarrierConfiguration.Commands;

public static class CarrierConfigurationAdd
{
    public record Command(CarrierConfigurationAddDto CarrierConfigurationAddDto) : IRequest<Response<NoDataDto>>;
    
    public class Handler: IRequestHandler<Command,Response<NoDataDto>>
    {
        private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
        private readonly IMapper _mapper;

        public Handler(ICarrierConfigurationRepository carrierConfigurationRepository, IMapper mapper)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;
            _mapper = mapper;
        }

        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.CarrierConfiguration>(request.CarrierConfigurationAddDto);
            await _carrierConfigurationRepository.AddAsync(data);
            return Response<NoDataDto>.Success(200 ,"Carrier Configuration Added.");
        }
    }
}