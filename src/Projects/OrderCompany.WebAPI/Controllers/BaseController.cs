using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderCompany.Shared.Dtos;

namespace OrderCompany.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator? _mediator;
    
    public IActionResult ActionResultInstance<T>(Response<T> response) where T: class
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}