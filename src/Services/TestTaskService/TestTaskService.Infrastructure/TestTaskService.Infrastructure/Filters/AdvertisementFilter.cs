using TestTaskService.Application.Dtos.Advertisement.Filters;
using TestTaskService.Application.Interfaces.Filters;
using TestTaskService.Application.Interfaces.Specification;
using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Infrastructure.Extensions;

namespace TestTaskService.Infrastructure.Filters;

public class AdvertisementFilter : IAdvertisementFilter
{
    private IQueryable<Advertisement> _advertisements;

    public AdvertisementFilter(IQueryable<Advertisement> advertisements)
    {
        _advertisements = advertisements;
    }
    
    public IAdvertisementFilter TitleFilter(ISpecification<Advertisement> titleSpecification)
    {
        _advertisements = _advertisements.ApplySpecify(titleSpecification);
        
        return this;
    }

    public IAdvertisementFilter RateFilter(ISpecification<Advertisement> rateSpecification)
    {
        _advertisements = _advertisements.ApplySpecify(rateSpecification);

        return this;
    }

    public IAdvertisementFilter ExpireDateFilter(ISpecification<Advertisement> expireDateSpecification)
    {
        _advertisements = _advertisements.ApplySpecify(expireDateSpecification);

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