using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration.UserSecrets;
using Tests.User.Api.Models;
using Tests.User.Api.Services;

namespace Tests.User.Api.Controllers;

[Route("api/user")]
public class UserController : Controller
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Gets a user
    /// </summary>
    /// <param name="id">ID of the user</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _service.GetUserByIdAsync(id);
        if (user.Id == 0)
        {
            return NotFound(user);
        }
        return Ok(user);
    }

    /// <summary>
    ///     Create a new user
    /// </summary>
    /// <param name="firstName">First name of the user</param>
    /// <param name="lastName">Last name of the user</param>
    /// <param name="age">Age of the user (must be a number)</param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }

        var createdUser = await _service.CreateAsync(dto);

        if (createdUser == null)
        {
            return BadRequest();
        }

        return Ok(createdUser);
    }

    /// <summary>
    ///     Updates a user
    /// </summary>
    /// <param name="id">ID of the user</param>
    /// <param name="firstName">First name of the user</param>
    /// <param name="lastName">Last name of the user</param>
    /// <param name="age">Age of the user (must be a number)</param>
    /// <returns></returns>
    [HttpPut]
    [Route("update/{userId}")]
    public async Task<IActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserDto dto)
    {
        var user = await _service.UpdateAsync(userId, dto);

        if (user.Id == 0)
        {
            return BadRequest();
        }

        return Ok(user);
    }

    /// <summary>
    ///     Delets a user
    /// </summary>
    /// <param name="userId">ID of the user</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete/{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        if (await _service.DeleteAsync(userId))
        {
            return Ok();
        }

        return BadRequest();
    }
}
