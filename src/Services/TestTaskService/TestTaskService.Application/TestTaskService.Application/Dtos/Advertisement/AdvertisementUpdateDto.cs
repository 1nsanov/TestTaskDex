namespace TestTaskService.Application.Dtos.Advertisement;

public class AdvertisementUpdateDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Rate { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime ExpireDate { get; set; }
}