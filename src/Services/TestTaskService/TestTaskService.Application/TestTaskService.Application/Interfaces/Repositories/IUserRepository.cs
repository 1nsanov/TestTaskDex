using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Application.Interfaces.Repositories;

/// <summary>
/// Репозиторий пользователя
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получение пользователя по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавление пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> AddAsync(User user, CancellationToken cancellationToken);
    
    /// <summary>
    /// Редактирование пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> UpdateAsync(User user, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    Task DeleteAsync(User user, CancellationToken cancellationToken);
}