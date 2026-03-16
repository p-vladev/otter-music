using Microsoft.AspNetCore.Mvc;
using Otter.Core.DTOs;
using Otter.Core.Entities;
using Otter.Core.Interfaces;
using Otter.Core.Services;

namespace Otter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
#pragma warning disable CA1515 // Consider making public types internal
public class AlbumController : ControllerBase
#pragma warning restore CA1515 // Consider making public types internal
{
    private readonly IAlbumService albumService;

    public AlbumController(IAlbumService albumService)
    {
        this.albumService = albumService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumDto dto, long artistId)
    {
        try
        {
            var response = await albumService.CreateAlbum(artistId, dto);

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
