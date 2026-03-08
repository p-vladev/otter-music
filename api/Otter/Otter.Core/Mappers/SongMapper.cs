using Otter.Core.DTOs;
using Otter.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Mappers;

public static class SongMapper
{
    public static SongDto ToSongDto(this Song song)
    {
        ArgumentNullException.ThrowIfNull(song, nameof(song));

        return new SongDto
        (
            song.Id,
            song.Title,
            song.Duration,
            song.AlbumId,
            song.CoverImageUrl,
            song.FileUrl,
            song.ReleaseDate,
            song.GenreId
        );
    }

    public static Song ToEntity(this CreateSongDto dto)
    {
        ArgumentNullException.ThrowIfNull (dto, nameof(dto));

        return new Song
        {
            Title = dto.Title,
            Duration = 100,
            AlbumId = dto.AlbumId,
            CoverImageUrl = dto.CoverImageUrl,
            FileUrl = dto.FileUrl,
            ReleaseDate = dto.ReleaseDate,
            GenreId = dto.GenreId,
            Album = null!,
            Genre = null!
        };
    }
}
