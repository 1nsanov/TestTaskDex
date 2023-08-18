using service.main.domain.Domain.Advertisements;

namespace service.main.domain.Interfaces.Filters;

public interface IAdvertisementFilter
{
    public IAdvertisementFilter TitleFilter(string? title);
    
    public IAdvertisementFilter RateFilter(int? minRate);
    
    public IAdvertisementFilter ExpireDateFilter(DateTime? expireDate);

    public IQueryable<Advertisement> Sort(AdvertisementSortOrder sortOrder);
}