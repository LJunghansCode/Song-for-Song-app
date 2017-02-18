namespace playlist.Models
{
    public class Playlist : BaseEntity
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public int SongId {get; set;}
        public int Count {get; set;}
        public Song song {get; set;}
        public User user {get; set;}
        }
}
