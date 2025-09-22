using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConsumirApi.Interface;
using ConsumirApi.Model;
using Microsoft.IdentityModel.Tokens;

namespace ConsumirApi.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponse GenerateToken(User user)
    {
        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var expiation = DateTime.Now.AddHours(2);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };
        
         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
         var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

         var token = new JwtSecurityToken
         (
             issuer: issuer,
             audience: audience,
             claims: claims,
             expires: expiation,
             signingCredentials: credentials
         );
         
         var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

         return new TokenResponse
         {
             Token = tokenString,
             Expiration = expiation
         };
    }
}