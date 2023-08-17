namespace service.main.domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
}