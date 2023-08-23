using MediatR;
using TestTaskService.Application.Dtos.User;

namespace TestTaskService.Application.Commands.Users.UserAdd;

public record UserAddCommand(UserAddDto user) : IRequest<Guid>;