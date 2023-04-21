using MediatR;
using OrderCompany.Application.Features.CarrierConfiguration.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.CarrierConfiguration.Commands;

public static class CarrierConfigurationDelete
{
    public record Command(int Id) : IRequest<Response<NoDataDto>>;
    
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
            await _carrierConfigurationRules.CarrierConfigurationIsFound(request.Id);
            var data = await _carrierConfigurationRepository.GetAsync(x => x.Id.Equals(request.Id));

            await _carrierConfigurationRepository.DeleteAsync(data);

            return Response<NoDataDto>.Success(200,"Carrier Configuration Deleted.");
        }
    }
}