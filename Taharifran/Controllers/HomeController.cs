using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taharifran.Models;

namespace Taharifran.Controllers
{
    public class HomeController : Controller
    {
        userdbEntities db = new userdbEntities();


        public ActionResult Index(string searching)
        {
           
            return View(db.Users.Where(x => x.Firstname.StartsWith(searching) || searching == null).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }

    

}