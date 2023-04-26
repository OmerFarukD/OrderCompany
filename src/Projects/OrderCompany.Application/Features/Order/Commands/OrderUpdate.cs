using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.Order.Dtos;
using OrderCompany.Application.Features.Order.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.Order.Commands;

public static class OrderUpdate
{
    public record Command(OrderUpdateDto OrderUpdateDto) : IRequest<Response<NoDataDto>>;
    
    
    public class Handler : IRequestHandler<Command,Response<NoDataDto>>
    {

        private readonly IOrderRepository _orderRepository;
        private readonly OrderBusinessRule _orderBusinessRule;
        private readonly IMapper _mapper;

        public Handler(IOrderRepository orderRepository, OrderBusinessRule orderBusinessRule, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderBusinessRule = orderBusinessRule;
            _mapper = mapper;
        }
        public async Task<Response<NoDataDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Order>(request.OrderUpdateDto);

            await _orderBusinessRule.OrderIsFound(data.Id);

            await _orderRepository.UpdateAsync(data);
            
            return Response<NoDataDto>.Success(200,"Order is updated");
        }
    }
}