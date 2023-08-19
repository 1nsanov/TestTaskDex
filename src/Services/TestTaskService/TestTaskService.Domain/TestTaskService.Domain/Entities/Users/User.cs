using Microsoft.EntityFrameworkCore;
using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Entities.Core;

namespace TestTaskService.Domain.Entities.Users;

public class User : BaseEntity
{
    public string Login { get; set; } = null!;
    public FullName FullName { get; set; } = null!;
    public bool IsAdmin { get; set; }

    public List<Advertisement> Advertisements { get; set; } = new();
}

[Owned]
public class FullName
{
    public string Family { get; set; } = null!;
    public string Given { get; set; } = null!;
    public string Middle { get; set; } = null!;
}