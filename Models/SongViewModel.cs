using System.ComponentModel.DataAnnotations;
namespace playlist.Models
{
    public class SongViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Artist { get; set; }
        [Required]
        [MinLength(2)]
        public string Title { get; set; }  
        [Required(ErrorMessage = "Please enter an Embed Code!")]
        public string EmbedLink {get; set;}     
        public string Genre {get; set;}
        public string Description {get; set;}
    }
}



