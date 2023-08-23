using MediatR;
using TestTaskService.Application.Dtos.User;

namespace TestTaskService.Application.Commands.Users.UserUpdate;

public record UserUpdateCommand(UserDto user) : IRequest<Guid>;