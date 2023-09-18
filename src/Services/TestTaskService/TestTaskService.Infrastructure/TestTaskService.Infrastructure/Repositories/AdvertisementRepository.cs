using Microsoft.EntityFrameworkCore;
using TestTaskService.Application.Dtos.Advertisement.Filters;
using TestTaskService.Application.Dtos.Common;
using TestTaskService.Application.Interfaces.Repositories;
using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Infrastructure.Data.DbContexts;
using TestTaskService.Infrastructure.Extensions;
using TestTaskService.Infrastructure.Filters;
using TestTaskService.Infrastructure.Specifications;

namespace TestTaskService.Infrastructure.Repositories;

/// <summary>
/// Репозиторий объявлений
/// </summary>
public class AdvertisementRepository : IAdvertisementRepository
{
    private readonly AppDbContext _dbContext;

    public AdvertisementRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PagedResult<Advertisement>> SearchAndSortAsync(AdvertisementFilterOptions filterOptions,
        int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var titleSpec = new TitleSpecification(filterOptions.SearchTerm);
        var rateSpec = new RateSpecification(filterOptions.MinRate);
        var expireDateSpec = new ExpireDateSpecification(filterOptions.ExpireDate);
        var sortSpec = new SortSpecification(filterOptions.SortOrder);
        
        // var query = new AdvertisementFilter(_dbContext.Advertisements)
        //     .TitleFilter(titleSpec)
        //     .RateFilter(rateSpec)
        //     .ExpireDateFilter(expireDateSpec)
        //     .Sort(filterOptions.SortOrder);

        var query = _dbContext.Advertisements
            .ApplySpecify(titleSpec)
            .ApplySpecify(rateSpec)
            .ApplySpecify(expireDateSpec)
            .ApplySpecify(sortSpec);

        var totalCount = await query.CountAsync(cancellationToken);
        
        var entities = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Advertisement>
        {
            Items = entities,
            TotalCount = totalCount
        };
    }

    public async Task<Advertisement?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Advertisements.FindAsync(new object?[] { id }, cancellationToken);
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
        var entity = await GetByIdAsync(advertisement.Id, cancellationToken);
        
        _dbContext.Entry(entity).CurrentValues.SetValues(advertisement);
        _dbContext.Entry(entity).Property(s => s.UserId).IsModified = false;
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return advertisement.Id;
    }

    public async Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken)
    {
        _dbContext.Remove(advertisement);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}