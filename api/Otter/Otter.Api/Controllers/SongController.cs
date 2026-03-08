using Microsoft.AspNetCore.Mvc;
using Otter.Core.DTOs;
using Otter.Core.Interfaces;
using Otter.Core.Services;

namespace Otter.Api.Controllers;

[ApiController]
[Route("api/song/[controller]")]
#pragma warning disable CA1515 // Consider making public types internal
public class SongController : ControllerBase
#pragma warning restore CA1515 // Consider making public types internal
{
    private readonly ISongService songService;

    public SongController(ISongService songService)
    {
        this.songService = songService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateSong([FromBody] CreateSongDto dto)
    {
        try
        {
            var response = await songService.CreateSong(dto);

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
