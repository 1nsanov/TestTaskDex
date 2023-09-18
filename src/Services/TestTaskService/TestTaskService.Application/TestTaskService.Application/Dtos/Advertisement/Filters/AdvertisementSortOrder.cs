namespace TestTaskService.Application.Dtos.Advertisement.Filters;

/// <summary>
/// Опции сортировки
/// </summary>
public enum AdvertisementSortOrder
{
    /// <summary>
    /// По умолчанию
    /// </summary>
    None,
    /// <summary>
    /// По номеру (возрастание)
    /// </summary>
    NumberAscending,
    /// <summary>
    /// По номеру (убывание)
    /// </summary>
    NumberDescending,
    /// <summary>
    /// По рейтингу (возрастание)
    /// </summary>
    RateAscending,
    /// <summary>
    /// По рейтингу (убывание)
    /// </summary>
    RateDescending,
    /// <summary>
    /// По сроку действия (возрастание)
    /// </summary>
    ExpirationDateAscending,
    /// <summary>
    /// По сроку действия (убывание)
    /// </summary>
    ExpirationDateDescending
}