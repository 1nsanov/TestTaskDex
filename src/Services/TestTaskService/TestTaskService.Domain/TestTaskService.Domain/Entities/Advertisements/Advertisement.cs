using TestTaskService.Domain.Entities.Core;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Domain.Entities.Advertisements;

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