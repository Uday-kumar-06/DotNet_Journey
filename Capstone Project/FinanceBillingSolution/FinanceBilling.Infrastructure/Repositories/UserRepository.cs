using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceBilling.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FinanceBillingDbContext _context;

    public UserRepository(FinanceBillingDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<IEnumerable<User>> GetPendingUsersAsync()
    {
        return await _context.Users
            .Where(x => !x.IsApproved)
            .ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetApprovedClientsAsync()
    {
        return await _context.Users
            .Include(x => x.Role)
            .Where(x =>
                x.IsApproved &&
                x.Role != null &&
                x.Role.RoleName == "Client")
            .ToListAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}