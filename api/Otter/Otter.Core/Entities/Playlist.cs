using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

public class Playlist
{
    public long Id { get; set; }

    [Required]
    public long UserId { get; set; }

    [Required]
    public int PlaylistTypeId { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    #pragma warning disable CA1056
    public string? CoverImageUrl { get; set; }
    #pragma warning restore CA1056

    public string? Description { get; set; }

    [Required]
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public required User User { get; set; }

    public required PlaylistType PlaylistType { get; set; }
}
