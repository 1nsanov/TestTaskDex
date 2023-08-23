using MediatR;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementDelete;

public record AdvertisementDeleteCommand(Guid id) : IRequest;