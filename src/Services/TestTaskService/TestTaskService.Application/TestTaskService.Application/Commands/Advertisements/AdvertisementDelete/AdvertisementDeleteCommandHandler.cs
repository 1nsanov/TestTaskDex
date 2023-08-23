using MediatR;
using TestTaskService.Application.Exceptions;
using TestTaskService.Domain.Repositories;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementDelete;

public class AdvertisementDeleteCommandHandler : IRequestHandler<AdvertisementDeleteCommand>
{
    private readonly IAdvertisementRepository _advertisementRepository;

    public AdvertisementDeleteCommandHandler(IAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public async Task Handle(AdvertisementDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _advertisementRepository.GetByIdAsync(request.id, cancellationToken)
                     ?? throw new EntityNotFoundException(request.id);

        await _advertisementRepository.DeleteAsync(entity, cancellationToken);
    }
}