using ConsumirApi.DTOS;
using ConsumirApi.Model;
using Frontend.Interface;

namespace Frontend.Service;

public class UserService : IUserService 
{
    private readonly HttpClient _client;

    public UserService(HttpClient client)
    {
        _client = client;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _client.GetFromJsonAsync<IEnumerable<User>>("User/GetUsers");
    }

    public async Task<User> GetUser(string username)
    {
        return await _client.GetFromJsonAsync<User>($"User/GetUser/{username}");
    }

    public async Task<bool> AddUser(User user)
    {
        var response = await _client.PostAsJsonAsync("User/AddUser", user);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateUser(int id, User user)
    {
        var response = await _client.PutAsJsonAsync($"User/UpdateUser/{id}", user);
        return response.IsSuccessStatusCode;    
    }

    public async Task<bool> DeleteUser(int id)
    {
        var response = await _client.DeleteAsync($"User/DeleteUser/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<string> Login(LoginDTO dto)
    {
        var response = await _client.PostAsJsonAsync("api/Auth/login", dto);
        
        if(!response.IsSuccessStatusCode) return null;
        
        var token = await response.Content.ReadAsStringAsync();
        return token;       
    }

    public async Task<bool> Register(User user)
    {
        var response = await _client.PostAsJsonAsync("api/Auth/register", user);
        return response.IsSuccessStatusCode;    
    }
}