using Microsoft.AspNetCore.Mvc;
using OrderCompany.Application.Features.CarrierConfiguration.Commands;
using OrderCompany.Application.Features.CarrierConfiguration.Dtos;
using OrderCompany.Application.Features.CarrierConfiguration.Queries;
using OrderCompany.Shared.Requests;

namespace OrderCompany.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrierConfigurationController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CarrierConfigurationAddDto dto)
    {
        var data = await Mediator.Send(new CarrierConfigurationAdd.Command(dto));
        return ActionResultInstance(data);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var data = await Mediator.Send(new CarrierConfigurationList.Query(pageRequest));
        return ActionResultInstance(data);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromQuery(Name = "id")] int id)
    {
        var data = await Mediator.Send(new CarrierConfigurationDelete.Command(id));
        return ActionResultInstance(data);
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] CarrierConfigurationUpdateDto dto)
    {
        var data = await Mediator.Send(new CarrierConfigurationUpdate.Command(dto));
        return ActionResultInstance(data);
    }

    [HttpPut("updatebycarrier")]
    public async Task<IActionResult> UpdateConigByCarrier([FromBody]CarrierConfigCarrierUpdateDto carrierConfigCarrierUpdateDto)
    {
        var data = await Mediator.Send(new CarrierConfigurationCarrierModify.Command(carrierConfigCarrierUpdateDto));
        return ActionResultInstance(data);
    }
}