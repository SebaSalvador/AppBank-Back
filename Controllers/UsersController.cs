using AppBank_Back.Application;
using AppBank_Back.Core;
using Microsoft.AspNetCore.Mvc;

namespace AppBank_Back.Controllers;

[ApiController]
[Route("api/[controller]")] // -> Genera la ruta /api/users
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpPost]
    public ActionResult<User> Create(User user)
    {
        try
        {
            var newUser = _userService.CreateUser(user);
            // Devuelve un 201 Created con la URL del nuevo recurso
            return CreatedAtAction(nameof(GetAll), new { id = newUser.Id }, newUser);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message); // Devuelve 400 Bad Request si la validación falla
        }
    }
}