using AutoMapper;
using TestTaskService.Application.Dtos.User;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserGetDto>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<User, UserListDto>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<UserAddDto, User>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<UserUpdateDto, User>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<FullName, FullNameDto>()
            .ReverseMap();
    }
}