using Otter.Core.DTOs;
using Otter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Mappers;

public static class AlbumMapper
{
    public static AlbumDto ToAlbumDto(this Album album, string artistName)
    {
        ArgumentNullException.ThrowIfNull(album, nameof(album));

        return new AlbumDto(
            album.Id,
            album.Title,
            //album.Artist.ArtistName,
            artistName,
            album.CoverImageUrl!,
            album.ReleaseDate
        );
    }

    public static Album ToEntity(this CreateAlbumDto dto, long artistId)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        return new Album
        {
            Title = dto.Title,
            ArtistId = artistId,
            CoverImageUrl = dto.CoverImageUrl,
            ReleaseDate = dto.ReleaseDate,
            GenreId = dto.GenreId,
            Artist = null!,
            Genre = null!,
        };
    }
}
