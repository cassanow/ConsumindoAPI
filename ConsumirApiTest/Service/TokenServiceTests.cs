using ConsumirApi.Repository;
using ConsumirApi.Service;
using ConsumirApiTest.Database;
using Microsoft.Extensions.Configuration;

namespace ConsumirApiTest.Service;

public class TokenServiceTests
{
    private IConfiguration Config()
    {
        var inMemoryConfig = new Dictionary<string, string>
        {
            { "Jwt:Issuer", "ConsumirApi" },
            { "Jwt:Audience", "User" },
            { "Jwt:Key", "24vu80v4b894vbh84bh8924bh894bh8924bh8942bh89b42bh894b2h89b24" }
        };
        
        return new ConfigurationBuilder()
            .AddInMemoryCollection(inMemoryConfig)
            .Build();
    }

    [Fact]
    public async Task ShouldReturnToken()
    {
        var context = TestDbContext.InMemoryDbContext();
        var repository = new UserRepository(context);
        var config =  Config(); 
        var user = TestDbContext.CreateUser();
        var service = new TokenService(config);

        await repository.AddUser(user);
        var result = service.GenerateToken(user);
        
        Assert.NotNull(result);
        Assert.False(string.IsNullOrEmpty(result.Token));
    }
}