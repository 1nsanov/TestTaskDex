namespace TestTaskService.Domain.Filters.Models;

public class AdvertisementFilterOptions
{
    public string? SearchTerm { get; set; }
    public int? MinRate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public AdvertisementSortOrder SortOrder { get; set; }
}