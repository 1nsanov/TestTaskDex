using AutoMapper;
using MediatR;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Domain.Repositories;
using TestTaskService.Domain.Repositories.ModelDto;

namespace TestTaskService.Application.Queries.Advertisements.AdvertisementSearchAndSortAsync;

public class AdvertisementSearchAndSortAsyncQueryHandler : IRequestHandler<AdvertisementSearchAndSortAsyncQuery, PagedResult<AdvertisementListDto>>
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementSearchAndSortAsyncQueryHandler(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<AdvertisementListDto>> Handle(AdvertisementSearchAndSortAsyncQuery request, CancellationToken cancellationToken)
    {
        var result = await _advertisementRepository
            .SearchAndSortAsync(request.filterOptions, request.pageNumber, request.pageSize, cancellationToken);

        return new PagedResult<AdvertisementListDto>
        {
            Items = _mapper.Map<List<AdvertisementListDto>>(result.Items),
            TotalCount = result.TotalCount
        };
    }
}