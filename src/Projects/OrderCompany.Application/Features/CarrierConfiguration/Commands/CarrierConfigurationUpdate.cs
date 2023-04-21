using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Application.Features.CarrierConfiguration.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.CarrierConfiguration.Commands;

public static class CarrierConfigurationUpdate
{
    public record Command(CarrierConfigurationUpdateDto ConfigurationUpdateDto) : IRequest<Response<NoDataDto>>;
    
    public class Handler: IRequestHandler<Command,Response<NoDataDto>>
    {
        private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
        private readonly IMapper _mapper;
        private readonly CarrierConfigurationRules _carrierConfigurationRules;

        public Handler(ICarrierConfigurationRepository carrierConfigurationRepository, IMapper mapper, CarrierConfigurationRules carrierConfigurationRules)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;
            _mapper = mapper;
            _carrierConfigurationRules = carrierConfigurationRules;
        }
        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.CarrierConfiguration>(request.ConfigurationUpdateDto);

            await _carrierConfigurationRules.CarrierConfigurationIsFound(data.Id);
            
            await _carrierConfigurationRepository.UpdateAsync(data);
            
            return Response<NoDataDto>.Success(200 ,"Carrier Configuration Updated.");
        }
    }
}