using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taharifran.Models;

namespace Taharifran.Controllers
{
    public class ProfilePageController : Controller
    {


        // GET: ProfilePage
        [Authorize()]
        public ActionResult Details()
        {
            var infoContext = new ApplicationDbContext();

            var UserId = User.Identity.GetUserId();
            var comp = infoContext.Users.Where(i => i.UserName == UserId).First();

            return View(comp);
        }
    }
}