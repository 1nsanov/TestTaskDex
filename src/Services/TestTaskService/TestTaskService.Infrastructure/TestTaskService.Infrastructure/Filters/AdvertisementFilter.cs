using Microsoft.EntityFrameworkCore;
using TestTaskService.Application.Dtos.Advertisement.Filters;
using TestTaskService.Application.Interfaces.Filters;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Infrastructure.Filters;

public class AdvertisementFilter : IAdvertisementFilter
{
    private IQueryable<Advertisement> _advertisements;

    public AdvertisementFilter(IQueryable<Advertisement> advertisements)
    {
        _advertisements = advertisements;
    }
    
    public IAdvertisementFilter TitleFilter(string? title)
    {
        _advertisements = title switch
        {
            null => _advertisements,
            _ => _advertisements.Where(a => EF.Functions.ILike(a.Title, $"%{title}%"))
        };
        
        return this;
    }

    public IAdvertisementFilter RateFilter(int? minRate)
    {
        _advertisements = minRate switch
        {
            null => _advertisements,
            _ => _advertisements.Where(a => a.Rate >= minRate)
        };

        return this;
    }

    public IAdvertisementFilter ExpireDateFilter(DateTime? expireDate)
    {
        _advertisements = expireDate switch
        {
            null => _advertisements,
            _ => _advertisements.Where(a => a.ExpireDate >= expireDate)
        };

        return this;
    }

    public IQueryable<Advertisement> Sort(AdvertisementSortOrder sortOrder)
    {
        return sortOrder switch
        {
            AdvertisementSortOrder.NumberAscending => _advertisements.OrderBy(a => a.Number),
            AdvertisementSortOrder.NumberDescending => _advertisements.OrderByDescending(a => a.Number),
            AdvertisementSortOrder.RateAscending => _advertisements.OrderBy(a => a.Rate),
            AdvertisementSortOrder.RateDescending => _advertisements.OrderByDescending(a => a.Rate),
            AdvertisementSortOrder.ExpirationDateAscending => _advertisements.OrderBy(a => a.ExpireDate),
            AdvertisementSortOrder.ExpirationDateDescending => _advertisements.OrderByDescending(a => a.ExpireDate),
            _ => _advertisements
        };
    }
}