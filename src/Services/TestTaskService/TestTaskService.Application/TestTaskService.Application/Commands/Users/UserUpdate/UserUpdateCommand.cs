using MediatR;
using TestTaskService.Application.Dtos;

namespace TestTaskService.Application.Commands.Users.UserUpdate;

public record UserUpdateCommand(UserDto user) : IRequest<Guid>;