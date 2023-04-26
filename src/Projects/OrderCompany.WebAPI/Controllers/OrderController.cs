using Hangfire;
using Microsoft.AspNetCore.Mvc;
using OrderCompany.Application.Features.Order.Commands;
using OrderCompany.Application.Features.Order.Dtos;
using OrderCompany.Application.Features.Order.Queries;
using OrderCompany.Application.Services;
using OrderCompany.Application.Services.OrderReportService;
using OrderCompany.Shared.Requests;

namespace OrderCompany.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : BaseController
{

 

    [HttpPost("add")]
    public async Task<IActionResult> Add(OrderAddDto orderAddDto)
    {
        var data = await Mediator.Send(new OrderAdd.Command(orderAddDto));
        return ActionResultInstance(data);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll([FromQuery]PageRequest pageRequest)
    {
        var data = await Mediator.Send(new OrderList.Query(pageRequest));
        return ActionResultInstance(data);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] OrderUpdateDto orderUpdateDto)
    {
        var data = await Mediator.Send(new OrderUpdate.Command(orderUpdateDto));
        return ActionResultInstance(data);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] int id)
    {
        var data = await Mediator.Send(new OrderDelete.Command(id));
        return ActionResultInstance(data);
    }


}