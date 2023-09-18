using AutoMapper;
using MediatR;
using TestTaskService.Application.Interfaces.Repositories;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Application.Commands.Users.UserAdd;

public class UserAddCommandHandler : IRequestHandler<UserAddCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserAddCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UserAddCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<User>(request.user);

        await _userRepository.AddAsync(entity, cancellationToken);

        return entity.Id;
    }
}