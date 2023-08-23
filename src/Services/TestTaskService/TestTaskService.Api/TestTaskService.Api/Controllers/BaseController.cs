using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskService.Api.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}