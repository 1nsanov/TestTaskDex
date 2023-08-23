using AutoMapper;
using MediatR;
using TestTaskService.Application.Dtos.User;
using TestTaskService.Domain.Repositories;

namespace TestTaskService.Application.Queries.Users.UserGetAll;

public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserGetAllQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        var entities = await _userRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<List<UserDto>>(entities);
    }
}