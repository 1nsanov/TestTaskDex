using MediatR;
using TestTaskService.Application.Dtos.Advertisement;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementUpdate;

public record AdvertisementUpdateCommand(AdvertisementUpdateDto advertisement) : IRequest<Guid>;