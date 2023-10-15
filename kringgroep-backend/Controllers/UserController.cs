using kringgroep_backend.Models;
using kringgroep_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace kringgroep_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("users")]
    public ActionResult<List<User>> GetUsers()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("user/{id}")]
    public ActionResult<User> GetUser([FromRoute] int id)
    {
        var user = _userService.Get(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost("user")]
    public ActionResult<User> CreateUser([FromBody] User u)
    {
        var user = _userService.Create(u.Name);
        return Ok(user);
    }
}