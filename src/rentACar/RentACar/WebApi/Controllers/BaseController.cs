using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    // əgər null deyilsə - mediatır əvvəlcədən injection edilibsə onu qaytar, null dır sa IOC dən IMediator un qarşılığını ver
}
