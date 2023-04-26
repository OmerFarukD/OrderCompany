using MediatR;
using OrderCompany.Application.Features.Order.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.Order.Commands;

public static class OrderDelete
{
    public record Command(int Id) : IRequest<Response<NoDataDto>>;
    
    public class Handler : IRequestHandler<Command,Response<NoDataDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderBusinessRule _orderBusinessRule;

        public Handler(IOrderRepository orderRepository, OrderBusinessRule orderBusinessRule)
        {
            _orderRepository = orderRepository;
            _orderBusinessRule = orderBusinessRule;
        }

        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
             await _orderBusinessRule.OrderIsFound(request.Id);

             var data = await _orderRepository.GetAsync(x=>x.Id.Equals(request.Id));

            await _orderRepository.DeleteAsync(data);
            return Response<NoDataDto>.Success(200,$"Order Deleted => Id : {request.Id} ");
        }
    }
}