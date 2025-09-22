using ConsumirApi.Model;

namespace ConsumirApi.Interface;

public interface ITokenService
{
    TokenResponse GenerateToken(User user);
}