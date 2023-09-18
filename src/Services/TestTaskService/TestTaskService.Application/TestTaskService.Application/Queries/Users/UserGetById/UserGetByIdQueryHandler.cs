using AutoMapper;
using MediatR;
using TestTaskService.Application.Dtos.User;
using TestTaskService.Application.Exceptions;
using TestTaskService.Application.Interfaces.Repositories;

namespace TestTaskService.Application.Queries.Users.UserGetById;

public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserGetDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserGetByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserGetDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.id, cancellationToken)
            ?? throw new EntityNotFoundException(request.id);

        return _mapper.Map<UserGetDto>(user);
    }
}