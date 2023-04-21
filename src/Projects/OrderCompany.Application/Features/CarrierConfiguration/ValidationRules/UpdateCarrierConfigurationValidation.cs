using FluentValidation;
using OrderCompany.Application.Features.CarrierConfiguration.Commands;

namespace OrderCompany.Application.Features.CarrierConfiguration.ValidationRules;

public class UpdateCarrierConfigurationValidation : AbstractValidator<CarrierConfigurationUpdate.Command>
{
    public UpdateCarrierConfigurationValidation()
    {
        RuleFor(x => x.ConfigurationUpdateDto.Id).NotNull();
        RuleFor(x => x.ConfigurationUpdateDto.CarrierMaxDesi).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ConfigurationUpdateDto.CarrierMinDesi).GreaterThanOrEqualTo(0);
    }
}