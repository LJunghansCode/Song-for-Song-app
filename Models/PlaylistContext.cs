using Microsoft.EntityFrameworkCore;

namespace playlist.Models
{
    public class PlaylistContext : DbContext
    {
        public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options)
        { }
        public DbSet<User> Users {get; set;}
        public DbSet<Song> Songs {get; set;}
        public DbSet<Playlist> Playlists {get; set;}
    }
}