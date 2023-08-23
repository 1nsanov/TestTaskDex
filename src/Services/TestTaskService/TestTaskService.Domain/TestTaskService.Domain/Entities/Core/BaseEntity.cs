namespace TestTaskService.Domain.Entities.Core;

/// <summary>
/// Базовый класс сущности
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }
}