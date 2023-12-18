using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.UserService; // Adjust the namespace based on your actual folder structure

using BusinessLogicLayer.DTOs;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDTO)
    {
        await _userService.AddUserAsync(userDTO);

        return CreatedAtAction(nameof(GetUserById), new { id = userDTO.UserId }, userDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
    {
        if (id != userDTO.UserId)
        {
            return BadRequest();
        }

        await _userService.UpdateUserAsync(userDTO);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var existingUser = await _userService.GetUserByIdAsync(id);

        if (existingUser == null)
        {
            return NotFound();
        }

        await _userService.DeleteUserAsync(id);

        return NoContent();
    }
}
