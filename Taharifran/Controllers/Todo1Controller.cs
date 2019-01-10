using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taharifran.Models;

namespace Taharifran.Controllers
{
    [Authorize]
    public class Todo1Controller : Controller
    {
        //// GET: Todo
        //public ActionResult Index()
        //{
        //    var ctx = new TodoDbContext();
        //    var userId = User.Identity.GetUserId();
        //    return View(new UserIndexViewModel
        //    {
        //        UserId = userId,
        //        TodoLists = ctx.TodoLists.Where(l => l.UserId == userId).ToList()
        //    });
        //}

        //// GET: Todo/ListDetail/id
        //public ActionResult ListDetail(int id)
        //{
        //    var ctx = new TodoDbContext();
        //    var list = ctx.TodoLists.FirstOrDefault(l => l.Id == id);
        //    return View(new ListDetailViewModel
        //    {
        //        UserId = User.Identity.GetUserId(),
        //        List = list
        //    });
        //}
    }
}