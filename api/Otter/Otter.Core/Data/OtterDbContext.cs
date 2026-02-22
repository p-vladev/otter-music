using Microsoft.EntityFrameworkCore;
using Otter.Core.Entities;

namespace Otter.Core.Data;

public class OtterDbContext : DbContext
{
    public OtterDbContext(DbContextOptions<OtterDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<PlaylistType> PlaylistTypes { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Playlist> Playlists { get; set; }

    public DbSet<PlaylistSong> PlaylistSongs { get; set; }
    public DbSet<UserSavedPlaylist> UserSavedPlaylists { get; set; }
    public DbSet<Authorship> Authorships { get; set; }
    public DbSet<UserRefreshToken> UserRefreshToken { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}