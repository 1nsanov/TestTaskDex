using TestTaskService.Application.Dtos.Advertisement.Filters;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Application.Interfaces.Filters;

/// <summary>
/// Фильтрация объявлений
/// </summary>
public interface IAdvertisementFilter
{
    /// <summary>
    /// Фильтр по заголовку
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public IAdvertisementFilter TitleFilter(string? title);
    
    /// <summary>
    /// Фильтр по рейтингу
    /// </summary>
    /// <param name="minRate"></param>
    /// <returns></returns>
    public IAdvertisementFilter RateFilter(int? minRate);
    
    /// <summary>
    /// Фильтр по дате истечения
    /// </summary>
    /// <param name="expireDate"></param>
    /// <returns></returns>
    public IAdvertisementFilter ExpireDateFilter(DateTime? expireDate);

    /// <summary>
    /// Сортировка
    /// </summary>
    /// <param name="sortOrder">опции</param>
    /// <returns></returns>
    public IQueryable<Advertisement> Sort(AdvertisementSortOrder sortOrder);
}