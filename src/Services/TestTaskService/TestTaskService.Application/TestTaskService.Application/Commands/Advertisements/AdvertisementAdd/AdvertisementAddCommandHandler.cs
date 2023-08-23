using AutoMapper;
using MediatR;
using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Repositories;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementAdd;

public class AdvertisementAddCommandHandler : IRequestHandler<AdvertisementAddCommand, Guid>
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementAddCommandHandler(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AdvertisementAddCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Advertisement>(request.advertisement);

        await _advertisementRepository.AddAsync(entity, cancellationToken);

        return entity.Id;
    }
}