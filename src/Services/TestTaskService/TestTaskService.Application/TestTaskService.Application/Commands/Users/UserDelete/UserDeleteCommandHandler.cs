using MediatR;
using TestTaskService.Application.Exceptions;
using TestTaskService.Application.Interfaces.Repositories;

namespace TestTaskService.Application.Commands.Users.UserDelete;

public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand>
{
    private readonly IUserRepository _userRepository;

    public UserDeleteCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userRepository.GetByIdAsync(request.id, cancellationToken)
                     ?? throw new EntityNotFoundException(request.id);

        await _userRepository.DeleteAsync(entity, cancellationToken);
    }
}