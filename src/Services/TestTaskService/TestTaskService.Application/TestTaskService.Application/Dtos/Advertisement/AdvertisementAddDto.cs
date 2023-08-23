namespace TestTaskService.Application.Dtos.Advertisement;

public class AdvertisementAddDto
{
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Rate { get; set; }
    public DateTime ExpireDate { get; set; }
    public Guid UserId { get; set; }
}