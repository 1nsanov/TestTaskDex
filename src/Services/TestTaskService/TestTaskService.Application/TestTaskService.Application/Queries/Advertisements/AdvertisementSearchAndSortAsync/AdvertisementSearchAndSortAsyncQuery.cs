using MediatR;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Application.Dtos.Advertisement.Filters;
using TestTaskService.Application.Dtos.Common;

namespace TestTaskService.Application.Queries.Advertisements.AdvertisementSearchAndSortAsync;

public record AdvertisementSearchAndSortAsyncQuery(AdvertisementFilterOptions filterOptions, int pageNumber, int pageSize) : IRequest<PagedResult<AdvertisementListDto>>;