using Microsoft.EntityFrameworkCore;
using Otter.Core.Data;
using Otter.Core.DTOs;
using Otter.Core.Interfaces;
using Otter.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Services;

public class ArtistService : IArtistService
{
    private readonly OtterDbContext context;

    public ArtistService(OtterDbContext context)
    {
        this.context = context;
    }

    public async Task<ArtistProfileDto> GetProfile(long artistId)
    {
        return await Task.FromException<ArtistProfileDto>(new NotImplementedException());
    }

    public async Task<IEnumerable<SongDto>> GetTopTracks(long artistId, int topCount = 5)
    {
        return await Task.FromException<IEnumerable<SongDto>>(new NotImplementedException());
    }

    public async Task<IEnumerable<AlbumDto>> GetAlbums(long artistId, int page = 1, int pageSize = 10)
    {
        return await Task.FromException<IEnumerable<AlbumDto>>(new NotImplementedException());
    }

    public async Task<IEnumerable<ArtistDto>> SearchArtists(string query, int page = 1, int pageSize = 20)
    {
        return await Task.FromException<IEnumerable<ArtistDto>>(new NotImplementedException());
    }

    public async Task<IEnumerable<ArtistDto>> GetRelatedArtists(long artistId, int limit = 5)
    {
        return await Task.FromException<IEnumerable<ArtistDto>>(new NotImplementedException());
    }

    public async Task<ArtistProfileDto> CreateArtistProfile(CreateArtistDto dto, long userId)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        if (await this.context.Artists.AnyAsync(a => a.UserId == userId))
        {
            throw new ArgumentException("User already an artist");
        }

        var artist = dto.ToEntity(userId);

        this.context.Artists.Add(artist);
        await this.context.SaveChangesAsync();

        var artistDto = artist.ToArtistProfileDto();

        return new ArtistProfileDto(
            artistDto.Id,
            artistDto.Name,
            artistDto.Biography
        );
    }

    public async Task<ArtistProfileDto> UpdateArtistProfile(long artistId, UpdateArtistDto dto)
    {
        return await Task.FromException<ArtistProfileDto>(new NotImplementedException());
    }
}
