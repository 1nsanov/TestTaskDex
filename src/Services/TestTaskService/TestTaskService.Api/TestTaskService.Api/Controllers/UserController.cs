using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTaskService.Application.Commands.Users.UserAdd;
using TestTaskService.Application.Commands.Users.UserDelete;
using TestTaskService.Application.Commands.Users.UserUpdate;
using TestTaskService.Application.Dtos;
using TestTaskService.Application.Dtos.User;
using TestTaskService.Application.Queries.Users.UserGetAll;
using TestTaskService.Application.Queries.Users.UserGetById;

namespace TestTaskService.Api.Controllers;

/// <summary>
/// Контроллер пользователей
/// </summary>
[Route("api/v1/user")]
public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Получение пользователя по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new UserGetByIdQuery(id), cancellationToken);

        return Ok(user);
    }
    
    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new UserGetAllQuery(), cancellationToken);

        return Ok(users);
    }

    /// <summary>
    /// Добавление пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserAddDto request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new UserAddCommand(request), cancellationToken);

        return Ok(id);
    }

    /// <summary>
    /// Редактирование пользователя
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new UserUpdateCommand(request), cancellationToken);

        return Ok(id);
    }

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UserDeleteCommand(id), cancellationToken);

        return Ok();
    }
}