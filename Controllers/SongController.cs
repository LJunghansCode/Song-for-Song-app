using System.Linq;
using Microsoft.AspNetCore.Mvc;
using playlist.Models;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Humanizer;

namespace playlist.Controllers
{
    public class SongController : Controller
    {
         
         private PlaylistContext _context;
         public SongController(PlaylistContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
             return View("Index");
        }
        // [HttpPost]
        // [Route("/NewSong")]
        // public IActionResult NewSong(SongViewModel model)
        // {   
        //     if(HttpContext.Session.GetInt32("userID") == null)
        //     {
        //         return Redirect("/");
        //     }


        //     if(ModelState.IsValid)
        //     {
        //         string embedCode = LinkToEmbed(model.EmbedLink);
        //         Song songInstance = new Song 
        //         {  
        //             Artist = model.Artist,
        //             Title = model.Title,
        //             CreatedAt = DateTime.Now,
        //             UpdatedAt = DateTime.Now,
        //             EmbedLink = embedCode,
        //             Description = model.Description,
        //             Genre = model.Genre,
        //             UserId = (int)HttpContext.Session.GetInt32("userID")
        //         };
        //         _context.Songs.Add(songInstance);
        //         _context.SaveChanges();
        //         return Redirect("/Songs");
        //     }
        //     return Redirect("/Songs");
        // }
               
        
        [HttpGet]
        
        [Route("/Song/{SongId}")]
        public IActionResult SongPage(int SongId)
        {
            if(HttpContext.Session.GetInt32("userID") == null){
                return Redirect("/");
            }
            Song songInstance = _context.Songs.SingleOrDefault(song => song.Id == SongId);
            ViewBag.usingUsers = _context.Playlists.Where(playlist => playlist.SongId == SongId).ToList();
            foreach (Playlist playlist in ViewBag.usingUsers)
            {
                User userInstance = _context.Users.SingleOrDefault(user => user.Id == playlist.UserId);
                playlist.user = userInstance;
            }
            ViewBag.SongTitle = songInstance.Title;
            ViewBag.SongArtist = songInstance.Artist;
            ViewBag.SongDescription = songInstance.Description;
            ViewBag.SongGenre = songInstance.Genre;
            
            return View ("SongPage"); 
        }
        [HttpGet]
       
        [Route("/User/{UserId}")]
        public IActionResult UserPage(int UserId)
        {
            if(HttpContext.Session.GetInt32("userID") == null){
                return Redirect("/");
            }
            User userInstance = _context.Users.SingleOrDefault(user => user.Id == UserId);
            ViewBag.MyPlaylist = _context.Playlists.Where(playlist => playlist.UserId == UserId).ToList().OrderBy(playlist => -playlist.Count);
            foreach (Playlist playlist in ViewBag.MyPlaylist)
            {
                Song songInstance = _context.Songs.SingleOrDefault(song => song.Id == playlist.SongId);
                playlist.song = songInstance;   
            }
            ViewBag.userFirstName = userInstance.FirstName;
            ViewBag.userFirstNameP = userInstance.FirstName + "'s";
            ViewBag.userLastName = userInstance.LastName;
            return View ("UserPage");
        }

    }
}
