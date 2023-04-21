using FluentValidation;
using OrderCompany.Application.Features.CarrierConfiguration.Commands;

namespace OrderCompany.Application.Features.CarrierConfiguration.ValidationRules;

public class CreateCarrierConfigurationValidation :AbstractValidator<CarrierConfigurationAdd.Command>
{
    public CreateCarrierConfigurationValidation()
    {
        RuleFor(x => x.CarrierConfigurationAddDto.CarrierCost).GreaterThanOrEqualTo(0).NotNull();
        RuleFor(x => x.CarrierConfigurationAddDto.CarrierMaxDesi).GreaterThanOrEqualTo(0).NotNull();
        RuleFor(x => x.CarrierConfigurationAddDto.CarrierMinDesi).GreaterThanOrEqualTo(0).NotNull();
        RuleFor(x => x.CarrierConfigurationAddDto.CarrierMinDesi).LessThan(x=>x.CarrierConfigurationAddDto.CarrierMaxDesi);
    }
}