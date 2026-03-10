using Microsoft.AspNetCore.Mvc;
using Otter.Core.DTOs;
using Otter.Core.Interfaces;
using Otter.Core.Services;

namespace Otter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
#pragma warning disable CA1515 // Consider making public types internal
public class ArtistController : ControllerBase
#pragma warning restore CA1515 // Consider making public types internal
{
    private readonly IArtistService artistService;

    public ArtistController(IArtistService artistService)
    {
        this.artistService = artistService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateArtistProfile([FromBody] CreateArtistDto dto, long userId)
    {
        try
        {
            var response = await artistService.CreateArtistProfile(dto, userId);

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
