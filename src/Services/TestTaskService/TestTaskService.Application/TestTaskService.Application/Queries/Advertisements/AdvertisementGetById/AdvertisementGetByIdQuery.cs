using MediatR;
using TestTaskService.Application.Dtos.Advertisement;

namespace TestTaskService.Application.Queries.Advertisements.AdvertisementGetById;

public record AdvertisementGetByIdQuery(Guid id) : IRequest<AdvertisementGetDto>;