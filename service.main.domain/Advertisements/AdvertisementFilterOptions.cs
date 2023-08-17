namespace service.main.domain.Advertisements;

public class AdvertisementFilterOptions
{
    public string? SearchTerm { get; set; }
    public int? MinRate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public AdvertisementSortOrder SortOrder { get; set; }
}