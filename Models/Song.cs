using System;

namespace playlist.Models
{
    public class Song : BaseEntity
    {
        
        public int Id {get; set;}
        public string Artist {get; set;}
        public string Title {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public int AddedTotal {get; set;}
        public string EmbedLink {get; set;}
        public string Description {get; set;}
        public string Genre {get; set;}
        public string TimeAgo {get; set;}
        public int UserId {get; set;}
        public User user {get; set;}
        

    }
}