using Otter.Core.DTOs;
using Otter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Mappers;

public static class ArtistMapper
{
    public static ArtistProfileDto ToArtistProfileDto(this Artist artist)
    {
        ArgumentNullException.ThrowIfNull(artist, nameof(artist));

        return new ArtistProfileDto(
            artist.Id,
            artist.ArtistName,
            artist.Biography
        );
    }

    public static Artist ToEntity(this CreateArtistDto dto, long userId)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        return new Artist
        {
            ArtistName = dto.Name,
            Biography = dto.Biography,
            UserId = userId,
            User = null!
        };
    }
}
