using Microsoft.AspNetCore.Mvc;
using Otter.Core.DTOs;
using Otter.Core.Interfaces;
using Otter.Core.Services;

namespace Otter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
#pragma warning disable CA1515 // Consider making public types internal
public class AuthController : ControllerBase
#pragma warning restore CA1515 // Consider making public types internal
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {  
        this.authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        try
        {
            // Контролер нічого не знає про БД чи хешування. Він просто просить сервіс зробити роботу.
            var response = await authService.Register(dto).ConfigureAwait(true);

            // Якщо все добре, повертаємо HTTP 200 (OK) і сам DTO з токеном
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            // Якщо сервіс викинув помилку (наприклад, "Email вже існує"), 
            // повертаємо HTTP 400 (Bad Request) з текстом помилки
            return BadRequest(new { message = ex.Message });
        }
    }
}
