namespace TestTaskService.Domain.Filters.ModelDto;

public class AdvertisementFilterOptions
{
    public string? SearchTerm { get; set; }
    public int? MinRate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public AdvertisementSortOrder SortOrder { get; set; }
}