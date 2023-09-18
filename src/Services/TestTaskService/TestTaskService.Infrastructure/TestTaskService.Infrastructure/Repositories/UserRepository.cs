using Microsoft.EntityFrameworkCore;
using TestTaskService.Application.Interfaces.Repositories;
using TestTaskService.Domain.Entities.Users;
using TestTaskService.Infrastructure.Data.DbContexts;

namespace TestTaskService.Infrastructure.Repositories;

/// <summary>
/// Репозиторий пользователей
/// </summary>
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
        var entity = await GetByIdAsync(user.Id, cancellationToken);

        _dbContext.Entry(entity).CurrentValues.SetValues(user);
        entity.FullName = user.FullName;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }
    
    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}