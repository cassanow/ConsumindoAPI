using ConsumirApi.DTOS;
using ConsumirApi.Model;

namespace Frontend.Interface;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(string username);
    Task<bool> AddUser(User user);
    Task<bool> UpdateUser(int id, User user);
    Task<bool> DeleteUser(int id);
    Task<string> Login(LoginDTO dto);
    Task<bool> Register(User user);
}