using playlist.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using playlist.Controllers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;


namespace playlist.Controllers
{
    [Route("api")]
    public class APIController : Controller
    {
        public PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
        public string LinkToEmbed(string youTubeLink)
        {
            string Embed = "";
            bool truth = false;
            for(int i = 0; i < youTubeLink.Length; i++)
            {
                if(truth == true)
                {
                    Embed += youTubeLink[i].ToString();
                }
                if(youTubeLink[i].ToString() == "=")
                {
                    truth = true;
                }
                
            }
            return Embed;
        }
        public string EmbedFromQuery(string returnOf)
        {
            string Embed = "";
            bool truth = false;
            for(int i = 0; i < returnOf.Length; i++)
            {
                if(truth == true)
                {
                    Embed += returnOf[i].ToString();
                }
                if(returnOf[i].ToString() == "(")
                {
                    truth = true;
                }
                if(returnOf[i].ToString() == ")")
                {
                    truth = false;
                }
                
            }
            return Embed;
        }
        
        private PlaylistContext _context;

         public APIController(PlaylistContext context)
        {
            _context = context;
        }
        [Route("/allSongs")]
        [HttpGet]
        public IActionResult allSongs()
        {
            List<Song> item = _context.Songs.ToList();
            if(item == null)
            {
                return NotFound();
            }
            return new JsonResult(item);
        }
        [Route("/getOneSong/{id}")]
        [HttpPost]
        public IActionResult getOne(int id)
        {
            System.Console.WriteLine(id);
            Song item = _context.Songs.FirstOrDefault(song => song.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return new JsonResult(item);
        }
        [Route("/new_song")]
        [HttpPost]
        public IActionResult newSong([FromBody]SongViewModel song)
        {  
           
            if(ModelState.IsValid){
                if(song.EmbedLink.Length >=12)
                 {
                    song.EmbedLink = LinkToEmbed(song.EmbedLink);
                 }
                Song songInstance = new Song 
                {
                    Artist = song.Artist,
                    Title = song.Title,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EmbedLink = song.EmbedLink,
                    Description = song.Description,
                    Genre = song.Genre,
                    UserId = (int)HttpContext.Session.GetInt32("userID")
                    
                };
                _context.Songs.Add(songInstance);
                _context.SaveChanges();
                int success = 1;
                return new ObjectResult(success);
            }
            return NotFound();
        }
        
        [Route("/Login")]  
        [HttpPost]
        public IActionResult login([FromBody]LoginModel loginInstance)
        {

           PasswordHasher<User> userHasher = new PasswordHasher<User>();
           User userLoggingInstance = _context.Users.SingleOrDefault(user => user.Email == loginInstance.Email );
           if(userLoggingInstance != null && loginInstance.Password != null)
           {

            if (0 != userHasher.VerifyHashedPassword(userLoggingInstance, userLoggingInstance.Password, loginInstance.Password))
            {
               HttpContext.Session.SetString("userFirstName", userLoggingInstance.FirstName);
               HttpContext.Session.SetInt32("userID", userLoggingInstance.Id);
               return new JsonResult(userLoggingInstance);
            }
            }
            return new JsonResult(null); 
        }

        [Route("/getCurUser")]  
        [HttpPost]
        public IActionResult GetCurUser()
        {
               User session = _context.Users.FirstOrDefault(user => user.Id == (int)HttpContext.Session.GetInt32("userID"));
               return new JsonResult(session);  
        }

        [HttpPost]
        [Route("/Register")]
        public IActionResult Register([FromBody]RegisterViewModel model)
        {
              if(ModelState.IsValid)
            {
                User ifExists = _context.Users.Where(user => user.Email == model.Email).FirstOrDefault();
                if(ifExists == null){
                User userInstance = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = Hasher.HashPassword(model, model.Password),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    


                };
                _context.Users.Add(userInstance);
                _context.SaveChanges();
                string success = "yes";
                return new JsonResult(success);
                 }
                
                return View("Index");
            }
            string fail = "yes";
            return new JsonResult(fail);
        }
         [HttpGet]
        [Route("/logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
        [HttpPost]
        [Route("/addToUser")]
        public IActionResult addToUser(int LoggedInUser, int SongId)
        {  
            if(HttpContext.Session.GetInt32("userID") == null){
                return Redirect("/");
            }
            Song songInstance = _context.Songs.SingleOrDefault(song=> song.Id == SongId);
            songInstance.AddedTotal += 1;
            Playlist tryToFind = _context.Playlists.Where(playlist=> playlist.UserId == LoggedInUser && playlist.SongId == SongId).SingleOrDefault();
            if(tryToFind == null)
                {
                Playlist PlaylistInstance = new Playlist
                {
                    UserId = LoggedInUser,
                    SongId = SongId,
                    Count = 1,
                };
                _context.Playlists.Add(PlaylistInstance);
                _context.SaveChanges();
                return Redirect("Songs");
            }
            else
            {
                tryToFind.Count += 1;
                _context.SaveChanges();
                return Redirect("Songs");
            }
        }
        
    }
}