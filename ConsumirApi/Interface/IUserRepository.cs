using ConsumirApi.Model;

namespace ConsumirApi.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetByUsername(string username);
    Task<User> GetById(int id);
    Task<bool> UserExists(int id);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);   
    Task<bool> DeleteUser(User user);
}