using Microsoft.EntityFrameworkCore;
using OrderCompany.Application.Features.Order.Dtos;
using OrderCompany.Application.Services.Repositories;
using OrderCompany.CrossCuttingConcerns.Exceptions;
using OrderCompany.Persistence.Paging;

namespace OrderCompany.Application.Features.Order.Rules;

public class OrderBusinessRule
{

    private readonly ICarrierRepository _carrierRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderBusinessRule(ICarrierRepository carrierRepository, IOrderRepository orderRepository)
    {
        _carrierRepository = carrierRepository;
        _orderRepository = orderRepository;
    }

    public async Task<OrderResponseDto> OrderDesiRule(int orderDesi)
    {
        
        var carriers = await DesiRangeRule(orderDesi);
        var minCost = carriers.Items.Min(x => x.CarrierConfiguration!.CarrierCost);
        var minCostCarrier =  carriers.Items.FirstOrDefault(x => x.CarrierConfiguration!.CarrierCost.Equals(minCost));

        var orderResponseDto = new OrderResponseDto()
        {
            CarrierId = minCostCarrier!.Id,
            CarrierName = minCostCarrier.CarrierName,
            OrderDesi = orderDesi,
            CarrierMaxDesi = minCostCarrier.CarrierConfiguration!.CarrierMaxDesi,
            CarrierMinDesi = minCostCarrier.CarrierConfiguration.CarrierMinDesi,
            OrderDesiCost = minCostCarrier.CarrierConfiguration.CarrierCost, 
            OrderCarrierCost = CalculateInvoice(orderDesi,minCostCarrier)
        };
        return orderResponseDto;
    }

    public async Task OrderIsFound(int orderId)
    {
        var data = await _orderRepository.GetAsync(x => x.Id.Equals(orderId));
        if (data is null) throw new BusinessException($"Order is not found => id: {orderId}");
    }
    
    
    // Private Rules
    private async Task<IPaginate<Domain.Entities.Carrier>> DesiRangeRule(int orderDesi)
    {
        var dataIsRanged = await _carrierRepository.GetListAsync(
            x => x.CarrierConfiguration!.CarrierMaxDesi >= orderDesi &&
                 x.CarrierConfiguration.CarrierMinDesi <= orderDesi,
            include: x => x.Include(c => c.CarrierConfiguration!)
        );
        if (dataIsRanged.Items.Count> 0) 
            return  dataIsRanged;

        return await _carrierRepository.GetListAsync(include:x => x.Include(c => c.CarrierConfiguration!)); 
    }
    
    private  decimal CalculateInvoice(int orderDesi, Domain.Entities.Carrier carrier)
    {
        var orderCarrierPlusDesiCost = carrier.CarrierPlusDesiCost;
        var carrierMaxDesi = carrier.CarrierConfiguration!.CarrierMaxDesi;
        decimal data=0;
        if (orderDesi>carrierMaxDesi)
        {
            data = orderCarrierPlusDesiCost * (orderDesi - carrierMaxDesi) + orderCarrierPlusDesiCost;
        }
        else
            data = orderCarrierPlusDesiCost;
        return data;
    }
}