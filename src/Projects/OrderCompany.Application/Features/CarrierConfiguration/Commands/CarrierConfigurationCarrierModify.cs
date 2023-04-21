using System.Security.Cryptography;
using MediatR;
using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Application.Features.CarrierConfiguration.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.CarrierConfiguration.Commands;

public static class CarrierConfigurationCarrierModify
{
    public record Command(CarrierConfigCarrierUpdateDto CarrierConfigCarrierUpdateDto) : IRequest<Response<NoDataDto>>;
    
    public class Handler : IRequestHandler<Command,Response<NoDataDto>>
    {

        private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
        private readonly CarrierConfigurationRules _carrierConfigurationRules;

        public Handler(ICarrierConfigurationRepository carrierConfigurationRepository, CarrierConfigurationRules carrierConfigurationRules)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;
            _carrierConfigurationRules = carrierConfigurationRules;
        }

        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            await _carrierConfigurationRules.CarrierConfigurationIsFound(request.CarrierConfigCarrierUpdateDto.ConfigId);
            await _carrierConfigurationRepository.CarrierConfigurationUpdateForCarrier(request.CarrierConfigCarrierUpdateDto.ConfigId,request.CarrierConfigCarrierUpdateDto.CarrierId);
            
            return Response<NoDataDto>.Success(200,"Carrier Configuration and CarrierUpdate");
        }
    }
}