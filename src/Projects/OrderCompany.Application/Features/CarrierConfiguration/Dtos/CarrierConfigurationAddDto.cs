namespace OrderCompany.Application.Features.CarrierConfiguration.Dtos;

public sealed record CarrierConfigurationAddDto(int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost);

