using FluentValidation;
using OrderCompany.Application.Features.Carrier.Commands;

namespace OrderCompany.Application.Features.Carrier.ValidationRules;

public class CreateCarrierValidation : AbstractValidator<CarrierAdd.Command>
{
    public CreateCarrierValidation()
    {
        RuleFor(x => x.CarrierAddDto.CarrierConfigurationId).NotNull().WithMessage("CarrierConfigurationId not null.");
        RuleFor(x => x.CarrierAddDto.CarrierPlusDesiCost).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CarrierAddDto.CarrierName).MinimumLength(3);
    }
}