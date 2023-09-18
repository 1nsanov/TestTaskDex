using AutoMapper;
using MediatR;
using TestTaskService.Application.Interfaces.Repositories;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementUpdate;

public class AdvertisementUpdateCommandHandler : IRequestHandler<AdvertisementUpdateCommand, Guid>
{
    private readonly IAdvertisementRepository _advertisementRepository;
    private readonly IMapper _mapper;

    public AdvertisementUpdateCommandHandler(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _advertisementRepository = advertisementRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AdvertisementUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Advertisement>(request.advertisement);

        await _advertisementRepository.UpdateAsync(entity, cancellationToken);

        return entity.Id;
    }
}