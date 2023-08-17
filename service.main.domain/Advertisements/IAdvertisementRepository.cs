using service.main.domain.Common;

namespace service.main.domain.Advertisements;

public interface IAdvertisementRepository
{
    Task<PagedResult<Advertisement>> SearchAndSortAsync(
        AdvertisementFilterOptions filterOptions,
        int pageNumber, int pageSize, CancellationToken cancellationToken);
    
    Task<Advertisement> AddAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task<Advertisement> UpdateAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken);
}