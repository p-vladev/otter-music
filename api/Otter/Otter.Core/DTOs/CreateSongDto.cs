using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.DTOs;

public record CreateSongDto(
        string Title,
        long AlbumId,
#pragma warning disable CA1056, CA1054 // URI-like parameters should not be strings
        string? CoverImageUrl,
        string FileUrl,
#pragma warning restore CA1056, CA1054 // URI-like parameters should not be strings
        DateTime? ReleaseDate,
        int GenreId
    );
