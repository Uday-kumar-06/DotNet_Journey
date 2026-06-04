using FinanceBilling.Core.Entities;

namespace FinanceBilling.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int userId);

    Task<User?> GetByUsernameAsync(string username);

    Task<User?> GetByEmailAsync(string email);

    Task<IEnumerable<User>> GetPendingUsersAsync();

    Task<IEnumerable<User>> GetApprovedClientsAsync();

    Task AddAsync(User user);

    Task UpdateAsync(User user);
}