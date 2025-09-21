using ConsumirApi.Database;
using ConsumirApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsumirApiTest.Database;

public static class TestDbContext
{
    public static AppDbContext InMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        var context = new AppDbContext(options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return context;
    }

    public static User CreateUser()
    {
        return new User
        {
            Id = 1,
            Username = "teste",
            Email = "teste@gmail.com",
            Password = "teste123",
            Role = 0,
        };
    }
}