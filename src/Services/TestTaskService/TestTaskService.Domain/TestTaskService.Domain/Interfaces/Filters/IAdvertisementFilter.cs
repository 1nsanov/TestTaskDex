using TestTaskService.Domain.Domain.Advertisements;

namespace TestTaskService.Domain.Interfaces.Filters;

public interface IAdvertisementFilter
{
    public IAdvertisementFilter TitleFilter(string? title);
    
    public IAdvertisementFilter RateFilter(int? minRate);
    
    public IAdvertisementFilter ExpireDateFilter(DateTime? expireDate);

    public IQueryable<Advertisement> Sort(AdvertisementSortOrder sortOrder);
}