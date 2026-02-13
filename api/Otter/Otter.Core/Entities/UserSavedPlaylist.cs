using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

[PrimaryKey(nameof(UserId), nameof(PlaylistId))]
public class UserSavedPlaylist
{
    [Required]
    public long UserId { get; set; }

    [Required]
    public long PlaylistId { get; set; }

    public DateTime SavedAt { get; set; } = DateTime.UtcNow;

    public required User User { get; set; }

    public required Playlist Playlist { get; set; }
}
