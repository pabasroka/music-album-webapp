using Microsoft.AspNetCore.Mvc;
using music_album_webapp.Models;
using music_album_webapp.Services;

namespace music_album_webapp.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
    {
        _userService.RegisterUser(dto);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginDto dto)
    {
        string token = _userService.GenerateJwtToken(dto);
        return Ok(token);
    }
    
}