namespace service.main.domain.Common;

public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
}