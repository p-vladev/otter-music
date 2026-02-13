using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

public class Album
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public long ArtistId { get; set; }

    #pragma warning disable CA1056
    public string? CoverImageUrl { get; set; }
    #pragma warning restore CA1056

    public DateTime? ReleaseDate { get; set; } = DateTime.MinValue;

    [Required]
    public int GenreId { get; set; }

    public required Artist Artist { get; set; }
    public required Genre Genre { get; set; }
}
