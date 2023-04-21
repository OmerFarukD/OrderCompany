using AutoMapper;
using MediatR;
using OrderCompany.Application.Features.Order.Dtos;
using OrderCompany.Application.Features.Order.Rules;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.Application.Features.Order.Commands;

public static class OrderAdd
{
    public record Command(OrderAddDto OrderAddDto) : IRequest<Response<OrderResponseDto>>;
    
    public class Handler : IRequestHandler<Command,Response<OrderResponseDto>>
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderBusinessRule _orderBusinessRule;

        public Handler(IOrderRepository orderRepository, IMapper mapper, OrderBusinessRule orderBusinessRule)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderBusinessRule = orderBusinessRule;
        }

        public async Task<Response<OrderResponseDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Domain.Entities.Order>(request.OrderAddDto);
            data.OrderTime=DateTime.Now;

            var response =await _orderBusinessRule.OrderDesiRule(request.OrderAddDto.OrderDesi);

            data.OrderCarrierCost = response.OrderCarrierCost;
            data.CarrierId = response.CarrierId;
            await _orderRepository.AddAsync(data);
            
            return Response<OrderResponseDto>.Success(response,"Sipariş eklendi.",200);
        }
    }
}