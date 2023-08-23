using TestTaskService.Domain.Entities.Core;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Domain.Entities.Advertisements;

/// <summary>
/// Объявление
/// </summary>
public class Advertisement : BaseEntity
{
    /// <summary>
    /// Номер
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; } = null!;
    
    /// <summary>
    /// Описание
    /// </summary>
    public string Text { get; set; } = null!;
    
    /// <summary>
    /// Рейтинг
    /// </summary>
    public int Rate { get; set; }
    
    /// <summary>
    /// Срок действия
    /// </summary>
    public DateTime ExpireDate { get; set; }
    
    /// <summary>
    /// Создатель
    /// </summary>
    public User User { get; set; } = null!;
    public Guid UserId { get; set; }
}