using Otter.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Interfaces;

public interface IAlbumService
{
    Task<AlbumDetailsDto> GetAlbumById(long albumId);

    Task<IEnumerable<AlbumDto>> GetNewReleases(int limit = 10);

    Task<IEnumerable<AlbumDto>> SearchAlbums(string query, int page = 1, int pageSize = 20);

    Task<AlbumDto> CreateAlbum(long artistId, CreateAlbumDto dto);

    Task<AlbumDetailsDto> UpdateAlbum(long albumId, UpdateAlbumDto dto);

    Task DeleteAlbum(long albumId);
}
