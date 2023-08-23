using MediatR;
using TestTaskService.Application.Dtos.Advertisement;

namespace TestTaskService.Application.Queries.Advertisement.AdvertisementGetById;

public record AdvertisementGetByIdQuery(Guid id) : IRequest<AdvertisementDto>;