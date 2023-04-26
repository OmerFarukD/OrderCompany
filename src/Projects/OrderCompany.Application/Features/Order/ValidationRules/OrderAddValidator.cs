using FluentValidation;
using OrderCompany.Application.Features.Order.Commands;

namespace OrderCompany.Application.Features.Order.ValidationRules;

public class OrderAddValidator : AbstractValidator<OrderAdd.Command>
{
    public OrderAddValidator()
    {
        RuleFor(x => x.OrderAddDto.OrderDesi).NotNull();
    }
}