using Microsoft.AspNetCore.Mvc;
using OrderCompany.Application.Features.Order.Commands;
using OrderCompany.Application.Features.Order.Dtos;

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
}