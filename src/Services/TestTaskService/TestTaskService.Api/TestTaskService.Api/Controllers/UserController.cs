using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTaskService.Application.Commands.Users.UserAdd;
using TestTaskService.Application.Commands.Users.UserDelete;
using TestTaskService.Application.Commands.Users.UserUpdate;
using TestTaskService.Application.Dtos;
using TestTaskService.Application.Queries.User.UserGetAll;
using TestTaskService.Application.Queries.User.UserGetById;

namespace TestTaskService.Api.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new UserGetByIdQuery(id), cancellationToken);

        return Ok(user);
    }
    
    [HttpGet("all")]
    
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new UserGetAllQuery(), cancellationToken);

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserDto request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new UserAddCommand(request), cancellationToken);

        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserDto request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new UserUpdateCommand(request), cancellationToken);

        return Ok(id);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UserDeleteCommand(id), cancellationToken);

        return Ok();
    }
}