using service.main.domain.Common;
using service.main.domain.Domain.Advertisements;
using service.main.domain.Repositories;
using service.main.infrastructure.Persistence.DbContexts;

namespace service.main.infrastructure.Persistence.Repositories;

public class AdvertisementRepository : IAdvertisementRepository
{
    private readonly AppDbContext _dbContext;

    public AdvertisementRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<PagedResult<Advertisement>> SearchAndSortAsync(AdvertisementFilterOptions filterOptions, int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Advertisement> AddAsync(Advertisement advertisement, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Advertisement> UpdateAsync(Advertisement advertisement, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}