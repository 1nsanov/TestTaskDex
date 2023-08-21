using MediatR;
using TestTaskService.Application.Dtos;

namespace TestTaskService.Application.Queries.User.UserGetById;

public record UserGetByIdQuery(Guid id) : IRequest<UserDto>;