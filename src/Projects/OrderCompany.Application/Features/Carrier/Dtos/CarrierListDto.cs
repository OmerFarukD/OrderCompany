﻿namespace OrderCompany.Application.Features.Carrier.Dtos;

public sealed record CarrierListDto(int Id, string? CarrierName, bool CarrierIsActive, int CarrierPlusDesiCost,int CarrierConfigurationId);
