using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        //Here we fetch the neccessary ids for the view
        [Authorize]
        public ActionResult OtherPost(ApplicationUser userProfile)
        {
                ApplicationDbContext db = new ApplicationDbContext();
                var id = userProfile.Id;
            
                var ctx = new WallPostDbContext();

                return View(new UserIndexViewModel
                {
                UserId = id,
                    WallPostList = ctx.WallPostList.Where(l => l.UserId == id).ToList()
                });
        }

        //here we fetch the neccesary ids for receiver and sender from the table and add it to a list
        [Authorize]
        public ActionResult FriendRequests()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var id = currentUser.Id;

            var ctx = new ApplicationDbContext();
            var requests = ctx.FriendRequests.Where(x => x.Reciever == id && x.Accepted == false).ToList();

            var usersThatSentFriendRequest = new List<ApplicationUser>();
            foreach (var request in requests)
            {
                var user = ctx.Users.FirstOrDefault(x => x.Id == request.Sender);
                usersThatSentFriendRequest.Add(user);
            }

            return View(new FriendRequestViewModel
            {
                FriendRequests = usersThatSentFriendRequest
            });
        }

        //here we fetch the ids for other users to load their information to their profilepage 
        [Authorize]
        public ActionResult otherProfile(ApplicationUser userProfile)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userId = userProfile.Id;

            var user = db.Users.Single(x => x.Id == userId);

            return View(user);
        }

        //here we fetch the id for other users to get their profilepicture on their profilpage
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

        //Here we create a search function which takes one parameter as searchvalue. It returns user if found in the database (Using startswith)
        [Authorize]
        public ActionResult Search(string searching)
        {
            return View(db.AspNetUsers.Where(x => x.Firstname.StartsWith(searching) || searching == null).ToList());

           
        }


        //first we check if the user is authenticated, if not, it will show a default user image.
        //else it will allow you to upload a own image from your library
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
                // here we get the user details to load user's Image
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