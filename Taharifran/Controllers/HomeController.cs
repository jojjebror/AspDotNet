using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taharifran.Models;

namespace Taharifran.Controllers
{
    public class HomeController : Controller
    {
        Entities1 db = new Entities1();


        public ActionResult Index(string searching)
        {
           
            return View(db.AspNetUsers.Where(x => x.Firstname.StartsWith(searching) || searching == null).ToList());
        }
        [Authorize]
        public ActionResult OtherPost(ApplicationUser userProfile)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var id = userProfile.Id;
            //ändra namn på databasen TodoDbCOntext och TodoList nedanför
                var ctx = new TodoDbContext();

            return View(new UserIndexViewModel
            {
                UserId = id,
                    TodoLists = ctx.TodoLists.Where(l => l.UserId == id).ToList()
                });
        }



        [Authorize]
        public ActionResult otherProfile(ApplicationUser userProfile)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userId = userProfile.Id;

            var user = db.Users.Single(x => x.Id == userId);

            return View(user);
        }

        public FileContentResult otherImage(ApplicationUser userProfile)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userId = userProfile.Id;

            var user = db.Users.Single(x => x.Id == userId);

            
            var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

            return new FileContentResult(userImage.UserPhoto, "image/jpeg");

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string searching)
        {
            return View(db.AspNetUsers.Where(x => x.Firstname.StartsWith(searching) || searching == null).ToList());

           
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId();

                if (userId == null)
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                }
                // to get the user details to load user Image
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

                return new FileContentResult(userImage.UserPhoto, "image/jpeg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }
        }


    }

    

}