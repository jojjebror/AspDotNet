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
        Entities1 db = new Entities1();


        public ActionResult Index(string searching)
        {
           
            return View(db.AspNetUsers.Where(x => x.UserName.StartsWith(searching) || searching == null).ToList());
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