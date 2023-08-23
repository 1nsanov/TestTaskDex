using MediatR;
using TestTaskService.Application.Dtos.User;

namespace TestTaskService.Application.Queries.Users.UserGetById;

public record UserGetByIdQuery(Guid id) : IRequest<UserGetDto>;