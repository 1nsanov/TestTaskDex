using MediatR;

namespace TestTaskService.Application.Commands.Users.UserDelete;

public record UserDeleteCommand(Guid id) : IRequest;