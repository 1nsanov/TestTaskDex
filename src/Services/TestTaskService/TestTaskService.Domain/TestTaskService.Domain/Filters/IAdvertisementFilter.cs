using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Filters.ModelDto;

namespace TestTaskService.Domain.Filters;

public interface IAdvertisementFilter
{
    public IAdvertisementFilter TitleFilter(string? title);
    
    public IAdvertisementFilter RateFilter(int? minRate);
    
    public IAdvertisementFilter ExpireDateFilter(DateTime? expireDate);

    public IQueryable<Advertisement> Sort(AdvertisementSortOrder sortOrder);
}