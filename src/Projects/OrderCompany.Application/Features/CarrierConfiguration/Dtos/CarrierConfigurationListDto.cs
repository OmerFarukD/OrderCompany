namespace OrderCompany.Application.Features.CarrierConfiguration.Dtos;

public sealed record CarrierConfigurationListDto(int Id, int CarrierId, int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost);