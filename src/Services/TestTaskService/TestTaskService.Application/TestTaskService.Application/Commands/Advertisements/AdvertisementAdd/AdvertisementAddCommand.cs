using MediatR;
using TestTaskService.Application.Dtos.Advertisement;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementAdd;

public record AdvertisementAddCommand(AdvertisementPostDto advertisement) : IRequest<Guid>;