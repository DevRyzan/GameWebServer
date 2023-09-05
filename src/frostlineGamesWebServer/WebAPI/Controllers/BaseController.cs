using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc; 

namespace WebAPI.Controllers;

public class BaseController:ControllerBase
{
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator? _mediator;

    protected string? getIpAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
        return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }

    protected Guid getUserIdFromRequest() //todo authentication behavior?
    {
        Guid userId = HttpContext.User.GetUserId();
        return userId;
    }
}
