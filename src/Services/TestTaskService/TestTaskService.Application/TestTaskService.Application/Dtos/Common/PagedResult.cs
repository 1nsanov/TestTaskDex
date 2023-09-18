namespace TestTaskService.Application.Dtos.Common;

public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
}