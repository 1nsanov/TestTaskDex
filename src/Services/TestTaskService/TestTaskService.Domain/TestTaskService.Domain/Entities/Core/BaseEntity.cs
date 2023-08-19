namespace TestTaskService.Domain.Entities.Core;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
}