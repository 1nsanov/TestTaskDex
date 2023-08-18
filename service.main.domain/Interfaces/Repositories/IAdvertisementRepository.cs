using service.main.domain.Common;
using service.main.domain.Domain.Advertisements;

namespace service.main.domain.Interfaces.Repositories;

public interface IAdvertisementRepository
{
    Task<PagedResult<Advertisement>> SearchAndSortAsync(
        AdvertisementFilterOptions filterOptions,
        int pageNumber, int pageSize, CancellationToken cancellationToken);
    
    Task<Guid> AddAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task<Guid> UpdateAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken);
}