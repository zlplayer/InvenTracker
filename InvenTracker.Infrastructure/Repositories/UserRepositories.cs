using InvenTracker.Domain.Entities;
using InvenTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure.Repositories;

public class UserRepositories : IUserRepositories
{
    private readonly InvenTrackerDbContext _dbContext;

    public UserRepositories(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetUsers() => await _dbContext.Users.Include(x=>x.Role).ToListAsync();
    
    public async Task<User?> GetUser(Guid id)
    {
        var user = await _dbContext.Users.Include(x=>x.Role).FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }
        
    public async Task<User?> GetUserByUsername(string username)
    {
        var user = await _dbContext.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Username == username);
        return user;
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }

    public async Task CreateUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteUser(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}