using BlazorApp1.Interface;
using ConsumirApi.DTOS;
using ConsumirApi.Model;

namespace BlazorApp1.Service;

public class UserService : IUserService 
{
    private readonly HttpClient _client;

    public UserService(HttpClient client)
    {
        _client = client;
    }
    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> Login(LoginDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Register(User user)
    {
        throw new NotImplementedException();
    }
}