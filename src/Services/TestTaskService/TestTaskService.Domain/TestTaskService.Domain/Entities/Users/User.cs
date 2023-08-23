using TestTaskService.Domain.Entities.Advertisements;
using TestTaskService.Domain.Entities.Core;

namespace TestTaskService.Domain.Entities.Users;

/// <summary>
/// Пользователь
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = null!;
    
    /// <summary>
    /// Полное имя
    /// </summary>
    public FullName FullName { get; set; } = null!;
    /// <summary>
    /// Роль админа
    /// </summary>
    public bool IsAdmin { get; set; }
    
    /// <summary>
    /// Список объявлений
    /// </summary>
    public List<Advertisement> Advertisements { get; set; } = new();
}

/// <summary>
/// Полное имя
/// </summary>
public class FullName
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Family { get; set; } = null!;
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Given { get; set; } = null!;
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string Middle { get; set; } = null!;
}