using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Filters.ModelDto;
using TestTaskService.Domain.Repositories.ModelDto;

namespace TestTaskService.Domain.Repositories;

/// <summary>
/// Репозиторий объявлений
/// </summary>
public interface IAdvertisementRepository
{
    /// <summary>
    /// Получение всех объявлений
    /// </summary>
    /// <param name="filterOptions">опции фильтров</param>
    /// <param name="pageNumber">номер страницы</param>
    /// <param name="pageSize">размер страницы</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PagedResult<Advertisement>> SearchAndSortAsync(
        AdvertisementFilterOptions filterOptions,
        int pageNumber, int pageSize, CancellationToken cancellationToken);

    /// <summary>
    /// Получение объявления по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Advertisement?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Добавление объявления
    /// </summary>
    /// <param name="advertisement"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> AddAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    /// <summary>
    /// Редактирование объявления
    /// </summary>
    /// <param name="advertisement"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> UpdateAsync(Advertisement advertisement, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаление объявления
    /// </summary>
    /// <param name="advertisement"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(Advertisement advertisement, CancellationToken cancellationToken);
}