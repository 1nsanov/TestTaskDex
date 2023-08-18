using service.main.domain.Common;
using service.main.domain.Domain.Advertisements;

namespace service.main.domain.Repositories;

public interface IAdvertisementRepository
{
    Task<PagedResult<Advertisement>> SearchAndSortAsync(
        AdvertisementFilterOptions filterOptions,
        int pageNumber, int pageSize, CancellationToken cancellationToken);
    
    Task<Advertisement> AddAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task<Advertisement> UpdateAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken);
}