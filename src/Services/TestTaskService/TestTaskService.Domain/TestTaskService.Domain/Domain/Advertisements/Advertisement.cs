using TestTaskService.Domain.Common;
using TestTaskService.Domain.Domain.Users;

namespace TestTaskService.Domain.Domain.Advertisements;

public class Advertisement : BaseEntity
{
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Rate { get; set; }
    public DateTime ExpireDate { get; set; }
    
    public User User { get; set; } = null!;
    public Guid UserId { get; set; }
}