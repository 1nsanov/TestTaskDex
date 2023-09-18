using TestTaskService.Application.Dtos.Advertisement.Filters;
using TestTaskService.Application.Interfaces.Specification;
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
    /// <param name="titleSpecification"></param>
    /// <returns></returns>
    public IAdvertisementFilter TitleFilter(ISpecification<Advertisement> titleSpecification);

    /// <summary>
    /// Фильтр по рейтингу
    /// </summary>
    /// <param name="rateSpecification"></param>
    /// <returns></returns>
    public IAdvertisementFilter RateFilter(ISpecification<Advertisement> rateSpecification);
    
    /// <summary>
    /// Фильтр по дате истечения
    /// </summary>
    /// <param name="expireDateSpecification"></param>
    /// <returns></returns>
    public IAdvertisementFilter ExpireDateFilter(ISpecification<Advertisement> expireDateSpecification);

    /// <summary>
    /// Сортировка
    /// </summary>
    /// <param name="sortOrder">опции</param>
    /// <returns></returns>
    public IQueryable<Advertisement> Sort(AdvertisementSortOrder sortOrder);
}