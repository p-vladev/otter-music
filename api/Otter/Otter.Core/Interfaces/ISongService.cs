using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter.Core.DTOs;

namespace Otter.Core.Interfaces;

public interface ISongService
{
    Task<SongDto> GetSongById(int id);

    Task<IEnumerable<SongDto>> SearchSong(string query,  int page = 1, int pageSize = 30);

    Task<SongDto> CreateSong(CreateSongDto dto);

    Task<SongDto> EditSong(long id);
}
