﻿using service.main.domain.Domain.Users;

namespace service.main.domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<Guid> AddAsync(User user, CancellationToken cancellationToken);
    
    Task<Guid> UpdateAsync(User user, CancellationToken cancellationToken);
    
    Task DeleteAsync(User user, CancellationToken cancellationToken);
}