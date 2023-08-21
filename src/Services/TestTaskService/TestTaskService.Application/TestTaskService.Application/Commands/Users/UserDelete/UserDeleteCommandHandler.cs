using AutoMapper;
using MediatR;
using TestTaskService.Application.Exceptions;
using TestTaskService.Domain.Repositories;

namespace TestTaskService.Application.Commands.Users.UserDelete;

public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserDeleteCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userRepository.GetByIdAsync(request.id, cancellationToken)
                     ?? throw new EntityNotFoundException(request.id);

        await _userRepository.DeleteAsync(entity, cancellationToken);
    }
}