namespace TestTaskService.Domain.Repositories.ModelDto;

public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
}