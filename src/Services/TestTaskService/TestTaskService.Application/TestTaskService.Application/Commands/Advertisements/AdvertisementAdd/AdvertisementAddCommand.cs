using MediatR;
using TestTaskService.Application.Dtos.Advertisement;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementAdd;

public record AdvertisementAddCommand(AdvertisementAddDto advertisement) : IRequest<Guid>;