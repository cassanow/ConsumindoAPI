using ConsumirApi.Database;
using ConsumirApi.Interface;
using ConsumirApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsumirApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();       
    }

    public async Task<bool> UserExists(int id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);      
    }

    public async Task<User> AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUser(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();  
        return true;
    }
}