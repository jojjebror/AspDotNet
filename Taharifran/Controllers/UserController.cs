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

       
        // GET: User
        public ActionResult Index()
        {
            var ctx = new UserDbContext();
            var viewModel = new UserIndexViewModel
            {
                Users = ctx.Users.ToList()
        };
            return View(viewModel);
        }

        

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
            var ctx = new TodoDbContext();
            var userId = User.Identity.GetUserId();
            return View(new UserIndexViewModel
            {
                UserId = userId,
                TodoLists = ctx.TodoLists.Where(l => l.UserId == userId).ToList()
            });
        }

        // GET: Todo/ListDetail/id
        public ActionResult ListDetail(int id)
        {
            var ctx = new TodoDbContext();
            var list = ctx.TodoLists.FirstOrDefault(l => l.Id == id);
            return View(new ListDetailViewModel
            {
                UserId = User.Identity.GetUserId(),
                List = list
            });
        }



        public ActionResult Profile()
        {

            var ctx = new UserDbContext();
            var viewModel = new UserIndexViewModel
            {
                Users = ctx.Users.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddUser(User model)
        {
            var ctx = new UserDbContext();
            ctx.Users.Add(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
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

        public ActionResult Lasse()
        {
            return View();
        }
    }
}