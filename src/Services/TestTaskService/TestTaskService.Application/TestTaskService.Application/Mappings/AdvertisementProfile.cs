﻿using AutoMapper;
using TestTaskService.Application.Dtos.Advertisement;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Application.Mappings;

public class AdvertisementProfile : Profile
{
    public AdvertisementProfile()
    {
        CreateMap<Advertisement, AdvertisementGetDto>();

        CreateMap<AdvertisementAddDto, Advertisement>();
        
        CreateMap<AdvertisementUpdateDto, Advertisement>();

        CreateMap<Advertisement, AdvertisementListDto>();
    }
}