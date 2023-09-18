using AutoMapper;
using MediatR;
using TestTaskService.Application.Interfaces.Repositories;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Application.Commands.Users.UserUpdate;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserUpdateCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<User>(request.user);

        await _userRepository.UpdateAsync(entity, cancellationToken);

        return entity.Id;
    }
}