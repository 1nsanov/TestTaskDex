using Microsoft.EntityFrameworkCore;
using TestTaskService.Domain.Domain.Users;
using TestTaskService.Domain.Interfaces.Repositories;
using TestTaskService.Infrastructure.Persistence.DbContexts;

namespace TestTaskService.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Users.ToListAsync(cancellationToken);
    }

    public async Task<Guid> AddAsync(User user, CancellationToken cancellationToken)
    {
        user.CreateDate = DateTime.UtcNow;
        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }

    public async Task<Guid> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }

    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}