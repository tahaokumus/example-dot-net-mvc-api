using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NewMvcProj.Models;
using NewMvcProj.Validations;

namespace NewMvcProj.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly UserValidator _userValidator = new();

    [HttpGet]
    public User[] GetUser()
    {
        return new[]
        {
            new User { UserName = "admin", Password = "123456", Email = "admin@gmail.com" },
            new User { UserName = "user", Password = "123456", Email = "user@gmail.com" },
        };
    }

    [HttpPost]
    public IActionResult AddUser(User newUser)
    {
        try
        {
            _userValidator.ValidateAndThrow(newUser);
        }
        catch (ValidationException e)
        {
            return BadRequest(
                new
                {
                    Message = e.Errors.FirstOrDefault()?.ErrorMessage
                }
            );
        }

        return Ok(newUser);
    }
}