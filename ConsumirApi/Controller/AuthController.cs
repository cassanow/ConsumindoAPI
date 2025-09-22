using ConsumirApi.DTOS;
using ConsumirApi.Interface;
using ConsumirApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _repository;

    public AuthController(ITokenService tokenService, IUserRepository repository)
    {
        _tokenService = tokenService;
        _repository = repository;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var user = await _repository.GetByUsername(dto.Username);
        
        if(user == null || user.Password != dto.Password)
            return BadRequest("Wrong password or User not found");    
        
        var token = _tokenService.GenerateToken(user);
        
        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(await _repository.UserExists(user.Id))
            return BadRequest("User already exists");

        await _repository.AddUser(user);
        
        return Ok(user);
    }
}