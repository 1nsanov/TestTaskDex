using MediatR;
using TestTaskService.Application.Dtos.User;

namespace TestTaskService.Application.Queries.Users.UserGetAll;

public record UserGetAllQuery() : IRequest<List<UserDto>>;