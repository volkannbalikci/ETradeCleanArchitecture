using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CustomControllerBase : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
