namespace OrderCompany.Application.Features.CarrierConfiguration.Dtos;

public sealed record CarrierConfigurationUpdateDto(int Id, int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost);