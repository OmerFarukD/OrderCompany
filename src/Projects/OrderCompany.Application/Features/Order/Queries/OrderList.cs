using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderCompany.Application.Features.Order.Models;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.Persistence.Paging;
using OrderCompany.Shared.Dtos;
using OrderCompany.Shared.Requests;

namespace OrderCompany.Application.Features.Order.Queries;

public static class OrderList
{
    public record Query(PageRequest PageRequest) : IRequest<Response<OrderListModel>>;
    
    public class Handler : IRequestHandler<Query,Response<OrderListModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public Handler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Response<OrderListModel>> Handle(Query request, CancellationToken cancellationToken)
        {
            var req = request.PageRequest;
            
            IPaginate<Domain.Entities.Order> orders = await _orderRepository.GetListAsync(index:req.Page,size:req.PageSize
                ,include:x=>x.Include(o=>o.Carrier!));

            OrderListModel model = _mapper.Map<OrderListModel>(orders);

            return Response<OrderListModel>.Success(model, "Orders Listed", 200);
        }
    }
}