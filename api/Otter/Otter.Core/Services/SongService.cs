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

public class SongService : ISongService
{
    private readonly OtterDbContext context;

    public SongService(OtterDbContext context)
    {
        this.context = context;
    }

    public async Task<SongDto> GetSongById(int id)
    {
        return await Task.FromException<SongDto>(new NotImplementedException());
    }

    public async Task<IEnumerable<SongDto>> SearchSong(string query, int page = 1, int pageSize = 30)
    {
        return await Task.FromException<IEnumerable<SongDto>>(new NotImplementedException());
    }

    public async Task<SongDto> CreateSong(CreateSongDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        var song = dto.ToEntity();

        this.context.Songs.Add(song);
        await context.SaveChangesAsync();

        var songdto = song.ToSongDto();

        return new SongDto(
            songdto.Id,
            songdto.Title,
            songdto.Duration,
            songdto.AlbumId,
            songdto.CoverImageUrl,
            songdto.FileUrl,
            songdto.ReleaseDate,
            songdto.GenreId
        );
    }

    public async Task<SongDto> EditSong(long id)
    {
        return await Task.FromException<SongDto>(new NotImplementedException());
    }
}
