using FluentValidation;
using OrderCompany.Application.Features.Carrier.Commands;

namespace OrderCompany.Application.Features.Carrier.ValidationRules;

public class UpdateCarrierValidation : AbstractValidator<CarrierUpdate.Command>
{
    public UpdateCarrierValidation()
    {
        RuleFor(x => x.CarrierUpdateDto.Id).NotNull().WithMessage("Id is required");
        RuleFor(x => x.CarrierUpdateDto.CarrierConfigurationId).NotNull().WithMessage("CarrierConfigurationId not null.");
        RuleFor(x => x.CarrierUpdateDto.CarrierPlusDesiCost).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CarrierUpdateDto.CarrierName).MinimumLength(3);
    }
}