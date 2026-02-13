using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

[PrimaryKey(nameof(PlaylistId), nameof(SongId))]
public class PlaylistSong
{
    [Required]
    public long PlaylistId { get; set; }

    [Required]
    public long SongId { get; set; }

    public DateTime AddedAt { get; set; } = DateTime.Now;

    [Required]
    public int OrderIndex { get; set; }

    public required Playlist Playlist { get; set; }

    public required Song Song { get; set; }
}