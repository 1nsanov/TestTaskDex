using AutoMapper;
using MediatR;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Application.Exceptions;
using TestTaskService.Domain.Repositories;

namespace TestTaskService.Application.Queries.Advertisement.AdvertisementGetById;

public class AdvertisementGetByIdQueryHandler : IRequestHandler<AdvertisementGetByIdQuery, AdvertisementDto>
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementGetByIdQueryHandler(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _mapper = mapper;
    }

    public async Task<AdvertisementDto> Handle(AdvertisementGetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _advertisementRepository.GetByIdAsync(request.id, cancellationToken)
                   ?? throw new EntityNotFoundException(request.id);

        return _mapper.Map<AdvertisementDto>(user);
    }
}