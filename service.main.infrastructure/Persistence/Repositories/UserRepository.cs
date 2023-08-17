using service.main.domain.Users;
using service.main.infrastructure.Persistence.DbContexts;

namespace service.main.infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}