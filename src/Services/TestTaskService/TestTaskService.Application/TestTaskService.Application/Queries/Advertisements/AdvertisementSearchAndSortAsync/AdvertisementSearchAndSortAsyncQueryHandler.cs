using AutoMapper;
using MediatR;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Domain.Repositories;

namespace TestTaskService.Application.Queries.Advertisements.AdvertisementSearchAndSortAsync;

public class AdvertisementSearchAndSortAsyncQueryHandler : IRequestHandler<AdvertisementSearchAndSortAsyncQuery, List<AdvertisementListDto>>
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementSearchAndSortAsyncQueryHandler(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _mapper = mapper;
    }

    public async Task<List<AdvertisementListDto>> Handle(AdvertisementSearchAndSortAsyncQuery request, CancellationToken cancellationToken)
    {
        var entities = await _advertisementRepository
            .SearchAndSortAsync(request.filterOptions, request.pageNumber, request.pageSize, cancellationToken);

        return _mapper.Map<List<AdvertisementListDto>>(entities);
    }
}