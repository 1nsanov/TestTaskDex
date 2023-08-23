using MediatR;
using TestTaskService.Application.Dtos.User;

namespace TestTaskService.Application.Queries.User.UserGetAll;

public record UserGetAllQuery() : IRequest<List<UserDto>>;