using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Taharifran.Models;



namespace Taharifran.Controllers
{   [Authorize]
    public class UserController : Controller
    {
        
        public ActionResult otherProfile(ApplicationUser userProfile)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userId = userProfile.Id;

            var user = db.Users.Single(x => x.Id == userId);

            return View(user);
        }

        // GET: Todo
        public ActionResult Post()
        {
            var ctx = new WallPostDbContext();
            var userId = User.Identity.GetUserId();
            return View(new UserIndexViewModel
            {
                UserId = userId,
                WallPostList = ctx.WallPostList.Where(l => l.UserId == userId).ToList()
            });
        }

        public ActionResult ProfilePage()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var ctx = new ApplicationDbContext();

            var requests = ctx.FriendRequests.Where(x => x.Reciever == currentUser.Id && x.Accepted == true).ToList();

            var friends = new List<ApplicationUser>();
            foreach (var request in requests)
            {
                var user = ctx.Users.FirstOrDefault(x => x.Id == request.Sender);
                friends.Add(user);
            }

            return View(new ProfileViewModel
            {
                Friends = friends,
                User = currentUser
            });
        }
        
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var path = "";
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                        Path.GetExtension(file.FileName).ToLower() == ".png" ||
                             Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                                Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
                        file.SaveAs(path);
                        ViewBag.UploadSuccess = true;
                    }
                }
            }

            return View();
        }

        
    }
}