// using System.Linq;
// using Microsoft.AspNetCore.Mvc;
// using playlist.Models;
// using Microsoft.AspNetCore.Http;
// using System;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Filters;

// namespace playlist.Controllers
// {
//     public class HomeController : Controller
//     {
//         public PasswordHasher<RegisterViewModel> Hasher = new PasswordHasher<RegisterViewModel>();
//          private PlaylistContext _context;
//          public HomeController(PlaylistContext context)
//         {
//             _context = context;
//         }
        // GET: /Home/

        // [HttpPost]
        // [Route("/Register")]
        // public IActionResult Register(RegisterViewModel model)
        // {
        //       if(ModelState.IsValid)
        //     {
        //         User ifExists = _context.Users.Where(user => user.Email == model.Email).FirstOrDefault();
        //         if(ifExists == null){
        //         User userInstance = new User
        //         {
        //             FirstName = model.FirstName,
        //             LastName = model.LastName,
        //             Email = model.Email,
        //             Password = Hasher.HashPassword(model, model.Password),
        //             CreatedAt = DateTime.Now,
        //             UpdatedAt = DateTime.Now,


        //         };
        //         _context.Users.Add(userInstance);
        //         _context.SaveChanges();
        //         ViewData["Success"] = "Thanks for Registering!! Please Login!";
        //         return View("Index");
        //          }
        //         ViewData["Success"] = "Hm, a user is already registered at this e-mail.";
        //         return View("Index");
        //     }
        //     return View("Index", model);
        // }

        // [HttpPost]
        // [Route("/Login")]
        // public IActionResult login(string email, string password)
        // {
        //    PasswordHasher<User> userHasher = new PasswordHasher<User>();
        //    User userLoggingInstance = _context.Users.SingleOrDefault(user => user.Email == email );
        //    if(userLoggingInstance != null && password != null)
        //    {

        //     if (0 != userHasher.VerifyHashedPassword(userLoggingInstance, userLoggingInstance.Password, password))
        //     {
        //        HttpContext.Session.SetString("userFirstName", userLoggingInstance.FirstName);
        //        HttpContext.Session.SetInt32("userID", userLoggingInstance.Id);
        //        return Redirect("/Songs"); 
        //     }
        //     }
        //     ViewData["Success"] = "Something failed on login";
        //     return View("Index");
        // }
        

//     }
// }
