using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTaskService.Application.Commands.Advertisements.AdvertisementAdd;
using TestTaskService.Application.Commands.Advertisements.AdvertisementDelete;
using TestTaskService.Application.Commands.Advertisements.AdvertisementUpdate;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Application.Queries.Advertisements.AdvertisementGetById;
using TestTaskService.Application.Queries.Advertisements.AdvertisementSearchAndSortAsync;
using TestTaskService.Domain.Filters.ModelDto;

namespace TestTaskService.Api.Controllers;

/// <summary>
/// Контроллер объявлений
/// </summary>
[Route("api/v1/advertisement")]
public class AdvertisementController : BaseController
{
    public AdvertisementController(IMediator mediator) : base(mediator)
    {
    }
    
    /// <summary>
    /// Получение объявления по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var advertisement = await _mediator.Send(new AdvertisementGetByIdQuery(id), cancellationToken);

        return Ok(advertisement);
    }
    
    /// <summary>
    /// Получение всех объявлений
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="filterOptions">опции фильтров</param>
    /// <param name="pageSize">размер страницы</param>
    /// <param name="pageNumber">номер страницы</param>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<IActionResult> SearchAndSort(
        CancellationToken cancellationToken,
        [FromQuery] AdvertisementFilterOptions filterOptions,
        [FromQuery][Range(1, 30)] int pageSize = 5,
        [FromQuery] int pageNumber = 1)
    {
        var advertisements = await _mediator.Send(new AdvertisementSearchAndSortAsyncQuery(filterOptions, pageNumber, pageSize), cancellationToken);

        return Ok(advertisements);
    }

    /// <summary>
    /// Добавление объявления
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AdvertisementAddDto request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new AdvertisementAddCommand(request), cancellationToken);

        return Ok(id);
    }

    /// <summary>
    /// Редактирование объявления
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AdvertisementUpdateDto request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new AdvertisementUpdateCommand(request), cancellationToken);

        return Ok(id);
    }

    /// <summary>
    /// Удаление объявления
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new AdvertisementDeleteCommand(id), cancellationToken);

        return Ok();
    }
}