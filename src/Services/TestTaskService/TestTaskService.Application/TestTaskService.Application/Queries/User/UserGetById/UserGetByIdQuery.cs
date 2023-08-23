using MediatR;
using TestTaskService.Application.Dtos.User;

namespace TestTaskService.Application.Queries.User.UserGetById;

public record UserGetByIdQuery(Guid id) : IRequest<UserDto>;