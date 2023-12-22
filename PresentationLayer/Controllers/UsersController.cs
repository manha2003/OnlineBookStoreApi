using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.UserService; // Adjust the namespace based on your actual folder structure
using BusinessLogicLayer.DTOs.UserDTO;

[Route("api/[controller]")]
[ApiController]
public class    UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTODetails>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTODetails>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTODetails>> CreateUser([FromBody] UserDTODetails userDTO)
    {
        await _userService.AddUserAsync(userDTO);

        return CreatedAtAction(nameof(GetUserById), new { id = userDTO.UserId }, userDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTODetails userDTO)
    {
        //if (id != userDTO.UserId)
        //{
        //    return BadRequest();
        //}

        //await _userService.UpdateUserAsync(userDTO);

        //return NoContent();

        var isUnique = await _userService.IsPhoneNumberUniqueAsync(userDTO.UserPhoneNumber)
           && await _userService.IsAddressUniqueAsync(userDTO.UserAddress)
           && await _userService.IsEmailUniqueAsync(userDTO.UserEmail);


        if (isUnique)
        {
            await _userService.AddUserAsync(userDTO);
            return CreatedAtAction(nameof(GetUserById), new { id = userDTO.UserId }, userDTO);
        }

        ModelState.AddModelError(!await _userService.IsPhoneNumberUniqueAsync(userDTO.UserPhoneNumber) ? "UserPhoneNumber" :
                                !await _userService.IsAddressUniqueAsync(userDTO.UserAddress) ? "Address" :
                                "UserEmail",
                                !await _userService.IsPhoneNumberUniqueAsync(userDTO.UserPhoneNumber) ? "This Phone number has been taken." :
                                !await _userService.IsAddressUniqueAsync(userDTO.UserAddress) ? "Address must be unique." :
                                "This Email has been taken.");
        // Bad Request = 400
        return BadRequest(ModelState);
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
