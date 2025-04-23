using Microsoft.AspNetCore.Mvc;
using Ustagram.Application.Abstractions;
using Ustagram.Domain.DTOs;
using Ustagram.Domain.Model;

namespace Ustagram.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<ActionResult<string>> CreateUser([FromForm] UserDTO userDto)
    {
        return await _service.CreateUser(userDto);
    }

    [HttpGet]
    public async Task<ActionResult<User>> GetUserById(Guid userId)
    {
        var user = await _service.GetUserById(userId);
        if (user == null)
            return NotFound("User not found");
        return Ok(user);
    }


    [HttpPut]
    public async Task<ActionResult<string>> UpdateUser(Guid userId, [FromForm] UserDTO userDto)
    {
        var user = await _service.UpdateUser(userId, userDto);
        if (user == null)
            return NotFound("User not found");
        return Ok(user);
    }


    [HttpDelete]
    public async Task<ActionResult<string>> DeleteUser(Guid userId)
    {
        var user = await _service.DeleteUser(userId);
        if (user == null)
            return NotFound("User not found");
        return Ok(user);
    }
    


    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return await _service.GetAllUsers();
    }
    
    
}