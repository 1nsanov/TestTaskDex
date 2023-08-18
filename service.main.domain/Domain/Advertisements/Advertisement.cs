﻿using service.main.domain.Common;
using service.main.domain.Domain.Users;

namespace service.main.domain.Domain.Advertisements;

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