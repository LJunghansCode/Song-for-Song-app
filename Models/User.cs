using System;
using System.Collections.Generic;



namespace playlist.Models
{
    public class User : BaseEntity
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Playlist> Playlist {get; set;}
        public User()
        {
            Playlist = new List<Playlist>();
        }



    }
}