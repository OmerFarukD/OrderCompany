using OrderCompany.Application.Services.Repositories;
using OrderCompany.CrossCuttingConcerns.Exceptions;

namespace OrderCompany.Application.Features.CarrierConfiguration.Rules;

public class CarrierConfigurationRules
{
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;

    public CarrierConfigurationRules(ICarrierConfigurationRepository carrierConfigurationRepository)
    {
        _carrierConfigurationRepository = carrierConfigurationRepository;
    }

    public async Task CarrierConfigurationIsFound(int id)
    {
        var data = await _carrierConfigurationRepository.GetAsync(x=>x.Id.Equals(id));

        if (data is null) throw new BusinessException($"Carrier Configuration is not found => id: {id}");
    }
}