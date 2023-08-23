using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Filters.ModelDto;
using TestTaskService.Domain.Repositories.ModelDto;

namespace TestTaskService.Domain.Repositories;

public interface IAdvertisementRepository
{
    Task<PagedResult<Advertisement>> SearchAndSortAsync(
        AdvertisementFilterOptions filterOptions,
        int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<Advertisement?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Guid> AddAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task<Guid> UpdateAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken);
}