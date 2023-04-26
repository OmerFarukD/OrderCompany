using Microsoft.AspNetCore.Mvc;
using OrderCompany.Application.Features.Carrier.Commands;
using OrderCompany.Application.Features.Carrier.Dtos;
using OrderCompany.Application.Features.Carrier.Queries;
using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Shared.Requests;

namespace OrderCompany.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrierController : BaseController
{
    
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CarrierAddDto carrierAddDto)
    {
        var data = await Mediator.Send(new CarrierAdd.Command(carrierAddDto));
        return ActionResultInstance(data);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var data = await Mediator.Send(new GetAllCarrier.Query(pageRequest));
        return ActionResultInstance(data);
    }

    [HttpDelete("delete")]

    public async Task<IActionResult> Delete([FromBody] int id)
    {
        var data = await Mediator.Send(new CarrierDelete.Command(id));
        return ActionResultInstance(data);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] CarrierUpdateDto carrierUpdateDto)
    {
        var data = await Mediator.Send(new CarrierUpdate.Command(carrierUpdateDto));
        return ActionResultInstance(data);
    }
    

}