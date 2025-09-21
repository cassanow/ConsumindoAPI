using ConsumirApi.Repository;
using ConsumirApiTest.Database;

namespace ConsumirApiTest.Repository;

public class RepositoryTests
{
    [Fact]
    public async Task ShouldReturnUsers()
    {
        var context = TestDbContext.InMemoryDbContext();
        var repository = new UserRepository(context);
        var user = TestDbContext.CreateUser();

        await repository.AddUser(user);
        var result = await repository.GetAll();
        
        Assert.NotNull(result);
        Assert.True(result.Any());  
    }
    
    [Fact]
    public async Task ShouldReturnUserById()
    {
        var context = TestDbContext.InMemoryDbContext();
        var repository = new UserRepository(context);   
        var user = TestDbContext.CreateUser();      
        
        await repository.AddUser(user);
        var result = await repository.GetById(user.Id);   
        
        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
    }

    [Fact]
    public async Task ShouldCreateUser()
    {
        var context = TestDbContext.InMemoryDbContext();
        var repository = new UserRepository(context);       
        var user = TestDbContext.CreateUser();
        
        var result = await repository.AddUser(user);
        
        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);   
        Assert.Equal(user.Email, result.Email);
    }

    [Fact]
    public async Task ShouldUpdateUser()
    {
        var context = TestDbContext.InMemoryDbContext();
        var repository = new UserRepository(context);   
        var user = TestDbContext.CreateUser();

        await repository.AddUser(user);
        user.Username = "testezinho";
        var result = await repository.UpdateUser(user);  
        
        Assert.NotNull(result);
        Assert.Equal(user.Username, result.Username);     
    }

    [Fact]
    public async Task ShouldDeleteUser()
    {
        var context = TestDbContext.InMemoryDbContext();
        var repository = new UserRepository(context);
        var user = TestDbContext.CreateUser();  
        
        await repository.AddUser(user);
        var result = await repository.DeleteUser(user); 
        
        Assert.True(result);
    }
}