namespace TestTaskService.Application.Dtos.Advertisement.Filters;

public class AdvertisementFilterOptions
{
    /// <summary>
    /// Поиск по заголовку
    /// </summary>
    public string? SearchTerm { get; set; }
    
    /// <summary>
    /// Минимальный рейтинг
    /// </summary>
    public int? MinRate { get; set; }
    
    /// <summary>
    /// Срок действия
    /// </summary>
    public DateTime? ExpireDate { get; set; }
    
    /// <summary>
    /// Опция сортировки
    /// </summary>
    public AdvertisementSortOrder SortOrder { get; set; }
}