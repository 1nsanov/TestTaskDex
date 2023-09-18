using AutoMapper;
using MediatR;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Application.Exceptions;
using TestTaskService.Application.Interfaces.Repositories;

namespace TestTaskService.Application.Queries.Advertisements.AdvertisementGetById;

public class AdvertisementGetByIdQueryHandler : IRequestHandler<AdvertisementGetByIdQuery, AdvertisementGetDto>
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementGetByIdQueryHandler(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _mapper = mapper;
    }

    public async Task<AdvertisementGetDto> Handle(AdvertisementGetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _advertisementRepository.GetByIdAsync(request.id, cancellationToken)
                   ?? throw new EntityNotFoundException(request.id);

        return _mapper.Map<AdvertisementGetDto>(user);
    }
}