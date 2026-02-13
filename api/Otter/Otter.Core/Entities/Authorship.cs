using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

[PrimaryKey(nameof(SongId), nameof(ArtistId))]
public class Authorship
{
    [Required]
    public long SongId { get; set; }

    [Required]
    public long ArtistId { get; set; }

    [Required]
    public bool IsMainArtist { get; set; } = true;

    public required Song Song { get; set; }

    public required Artist Artist { get; set; }
}
