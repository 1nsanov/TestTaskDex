using AutoMapper;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Application.Mappings;

public class AdvertisementProfile : Profile
{
    public AdvertisementProfile()
    {
        CreateMap<Advertisement, AdvertisementGetDto>();

        CreateMap<AdvertisementPostDto, Advertisement>();
        
        CreateMap<AdvertisementPutDto, Advertisement>();

        CreateMap<Advertisement, AdvertisementListDto>();
    }
}