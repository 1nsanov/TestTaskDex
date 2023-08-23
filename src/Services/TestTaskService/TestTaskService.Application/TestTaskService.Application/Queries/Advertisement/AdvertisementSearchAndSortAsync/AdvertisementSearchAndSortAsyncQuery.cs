using MediatR;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Domain.Filters.ModelDto;

namespace TestTaskService.Application.Queries.Advertisement.AdvertisementSearchAndSortAsync;

public record AdvertisementSearchAndSortAsyncQuery(AdvertisementFilterOptions filterOptions, int pageNumber, int pageSize) : IRequest<List<AdvertisementListDto>>;