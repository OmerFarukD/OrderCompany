using Microsoft.AspNetCore.Mvc;
using OrderCompany.Application.Features.CarrierReports.Commands;

namespace OrderCompany.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrierReportsController : BaseController
{
    [HttpPost("addreport")]
    public async Task<IActionResult> AddReports()
    {
        var data =await Mediator.Send(new AddReport.Command());
        return ActionResultInstance(data);
    }
}