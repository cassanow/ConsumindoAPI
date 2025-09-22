using ConsumirApi.DTOS;
using ConsumirApi.Model;

namespace ConsumirApi.Mapping;

public class LoginMapping
{
    public User ToUser(LoginDTO dto)
    {
        return new User
        {
            Username = dto.Username,
            Password = dto.Password
        };
    }

    public LoginDTO ToDTO(User user)
    {
        return new LoginDTO
        {
            Username = user.Username,
            Password = user.Password
        };
    }
}