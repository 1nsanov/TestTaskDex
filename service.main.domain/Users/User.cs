using Microsoft.EntityFrameworkCore;
using service.main.domain.Base;

namespace service.main.domain.Users;

public class User : BaseEntity
{
    public string Login { get; set; } = null!;
    public FullName FullName { get; set; } = null!;
    public bool IsAdmin { get; set; }
}

[Owned]
public class FullName
{
    public string Family { get; set; } = null!;
    public string Given { get; set; } = null!;
    public string Middle { get; set; } = null!;
}