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
            var response = await authService.Register(dto);

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        try
        {
            var response = await authService.Login(dto);

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string token)
    {
        try
        {
            var response = await authService.RefreshToken(token);

            return Ok(response);
        }
        catch (ArgumentException ex) 
        {
            return BadRequest($"{ex.Message}");
        }
    }
}
