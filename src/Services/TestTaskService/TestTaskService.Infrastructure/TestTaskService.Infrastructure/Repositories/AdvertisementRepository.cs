using Microsoft.EntityFrameworkCore;
using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Entities.Core;
using TestTaskService.Domain.Filters.Models;
using TestTaskService.Domain.Repositories;
using TestTaskService.Domain.Repositories.Models;
using TestTaskService.Infrastructure.Data.DbContexts;
using TestTaskService.Infrastructure.Filters;

namespace TestTaskService.Infrastructure.Repositories;

public class AdvertisementRepository : IAdvertisementRepository
{
    private readonly AppDbContext _dbContext;

    public AdvertisementRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PagedResult<Advertisement>> SearchAndSortAsync(AdvertisementFilterOptions filterOptions, int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var query = new AdvertisementFilter(_dbContext.Advertisements)
            .TitleFilter(filterOptions.SearchTerm)
            .RateFilter(filterOptions.MinRate)
            .ExpireDateFilter(filterOptions.ExpireDate)
            .Sort(filterOptions.SortOrder);

        var entities = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _dbContext.Advertisements.CountAsync(cancellationToken);
        
        return new PagedResult<Advertisement>
        {
            Items = entities,
            TotalCount = totalCount
        };
    }

    public async Task<Guid> AddAsync(Advertisement advertisement, CancellationToken cancellationToken)
    {
        advertisement.CreateDate = DateTime.UtcNow;
        await _dbContext.Advertisements.AddAsync(advertisement, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return advertisement.Id;
    }

    public async Task<Guid> UpdateAsync(Advertisement advertisement, CancellationToken cancellationToken)
    {
        _dbContext.Update(advertisement);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return advertisement.Id;
    }

    public async Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken)
    {
        _dbContext.Remove(advertisement);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}