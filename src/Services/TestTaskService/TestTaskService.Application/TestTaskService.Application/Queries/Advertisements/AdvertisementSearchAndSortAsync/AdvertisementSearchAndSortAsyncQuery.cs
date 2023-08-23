using MediatR;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Domain.Filters.ModelDto;
using TestTaskService.Domain.Repositories.ModelDto;

namespace TestTaskService.Application.Queries.Advertisements.AdvertisementSearchAndSortAsync;

public record AdvertisementSearchAndSortAsyncQuery(AdvertisementFilterOptions filterOptions, int pageNumber, int pageSize) : IRequest<PagedResult<AdvertisementListDto>>;