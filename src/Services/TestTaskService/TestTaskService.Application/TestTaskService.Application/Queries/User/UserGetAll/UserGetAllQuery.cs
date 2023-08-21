using MediatR;
using TestTaskService.Application.Dtos;

namespace TestTaskService.Application.Queries.User.UserGetAll;

public record UserGetAllQuery() : IRequest<List<UserDto>>;