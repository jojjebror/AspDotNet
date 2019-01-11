using Microsoft.AspNet.Identity;
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

            
            return View();
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