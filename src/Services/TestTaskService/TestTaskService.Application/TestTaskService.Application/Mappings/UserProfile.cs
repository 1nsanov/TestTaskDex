using AutoMapper;
using TestTaskService.Application.Dtos.User;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.FullName, 
                opt => opt.MapFrom(src => src.FullName))
            .ReverseMap();

        CreateMap<FullName, FullNameDto>()
            .ReverseMap();
    }
}