namespace service.main.domain.Users;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<User> AddAsync(User user, CancellationToken cancellationToken);
    
    Task<User> UpdateAsync(User user, CancellationToken cancellationToken);
    
    Task DeleteAsync(User user, CancellationToken cancellationToken);
}