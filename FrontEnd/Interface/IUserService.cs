using ConsumirApi.DTOS;
using ConsumirApi.Model;

namespace BlazorApp1.Interface;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(string username);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<bool> DeleteUser(int id);
    Task<string> Login(LoginDTO dto);
    Task<bool> Register(User user);
}