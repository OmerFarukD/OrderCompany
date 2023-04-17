using OrderCompany.Application.Services.Repositories;
using OrderCompany.CrossCuttingConcerns.Exceptions;

namespace OrderCompany.Application.Features.Carrier.Rules;

public class CarrierBusinessRules
{

    private readonly ICarrierRepository _carrierRepository;

    public CarrierBusinessRules(ICarrierRepository carrierRepository)
    {
        _carrierRepository = carrierRepository;
    }

    public async Task CarrierIsFound(int id)
    {
        var data = await _carrierRepository.GetAsync(x => x.Id.Equals(id));
        if (data is null) throw new BusinessException($"Carrier is not found => Id={id}");
    }
}