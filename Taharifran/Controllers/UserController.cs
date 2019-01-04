using System;
using System.Collections.Generic;
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
    }
}