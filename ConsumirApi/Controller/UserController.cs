using ConsumirApi.Interface;
using ConsumirApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirApi.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _repository.GetAll();
        
        if(users == null)
            return NotFound();
        
        return Ok(users);   
    }

    [HttpGet("GetUser/{username}")]
    public async Task<IActionResult> GetUser(string username)
    {
        var user = await _repository.GetByUsername(username);
        
        if(user == null)
            return NotFound();
        
        return Ok(user);    
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(await _repository.UserExists(user.Id))
            return BadRequest("User already exists");
        
        await _repository.AddUser(user);
        
        return Ok(user);
    }

    [HttpPut("UpdateUser/{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(!await _repository.UserExists(user.Id))
            return NotFound();

        await _repository.UpdateUser(user);
        
        return Ok(user);
    }

    [HttpDelete("DeleteUser/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _repository.GetById(id);
        
        if(user == null)
            return NotFound();
        
        await _repository.DeleteUser(user);
        
        return NoContent();
    }
}