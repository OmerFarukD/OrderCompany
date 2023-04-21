namespace OrderCompany.Application.Features.Carrier.Dtos;

public sealed record CarrierAndConfigurationDto(int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost,
    int CarrierPlusDesiCost, int CarrierConfigurationId, bool CarrierIsActive);