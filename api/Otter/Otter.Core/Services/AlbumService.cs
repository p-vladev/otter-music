using Microsoft.EntityFrameworkCore;
using Otter.Core.Data;
using Otter.Core.DTOs;
using Otter.Core.Entities;
using Otter.Core.Interfaces;
using Otter.Core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Services;

public class AlbumService : IAlbumService
{
    private readonly OtterDbContext context;

    public AlbumService(OtterDbContext context)
    {
        this.context = context;
    }

    public async Task<AlbumDetailsDto> GetAlbumById(long albumId)
    {
        return await Task.FromException<AlbumDetailsDto>(new NotImplementedException());
    }

    public async Task<IEnumerable<AlbumDto>> GetNewReleases(int limit = 10)
    {
        return await Task.FromException<IEnumerable<AlbumDto>>(new NotImplementedException());
    }

    public async Task<IEnumerable<AlbumDto>> SearchAlbums(string query, int page = 1, int pageSize = 20)
    {
        return await Task.FromException<IEnumerable<AlbumDto>>(new NotImplementedException());
    }

    public async Task<AlbumDto> CreateAlbum(long artistId, CreateAlbumDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        var album = dto.ToEntity(artistId);

        this.context.Albums.Add(album);
        await this.context.SaveChangesAsync();

        var artist = await context.Artists.FirstOrDefaultAsync(a => a.Id == artistId);

        ArgumentNullException.ThrowIfNull(artist, nameof(artist));

        var albumDto = album.ToAlbumDto(artist.ArtistName);

        return new AlbumDto(
            albumDto.Id,
            albumDto.Title,
            albumDto.ArtistName,
            albumDto.CoverImageUrl,
            albumDto.ReleaseDate
        );
    }

    public async Task<AlbumDetailsDto> UpdateAlbum(long albumId, UpdateAlbumDto dto)
    {
        return await Task.FromException<AlbumDetailsDto>(new NotImplementedException());
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task DeleteAlbum(long albumId)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
    }
}
