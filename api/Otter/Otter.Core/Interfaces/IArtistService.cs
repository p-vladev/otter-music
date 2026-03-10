using Otter.Core.DTOs;
using Otter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Interfaces;

public interface IArtistService
{
    Task<ArtistProfileDto> GetProfile(long artistId);

    Task<IEnumerable<SongDto>> GetTopTracks(long artistId, int topCount = 5);

    Task<IEnumerable<AlbumDto>> GetAlbums(long artistId, int page = 1, int pageSize = 10);

    Task<IEnumerable<ArtistDto>> SearchArtists(string query, int page = 1, int pageSize = 20);

    Task<IEnumerable<ArtistDto>> GetRelatedArtists(long artistId, int limit = 5);

    Task<ArtistProfileDto> CreateArtistProfile(CreateArtistDto dto, long userId);

    Task<ArtistProfileDto> UpdateArtistProfile(long artistId, UpdateArtistDto dto);
}
