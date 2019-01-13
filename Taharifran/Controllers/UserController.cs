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
        //gets id for other users profile from db
        public ActionResult otherProfile(ApplicationUser userProfile)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userId = userProfile.Id;

            var user = db.Users.Single(x => x.Id == userId);

            return View(user);
        }

        //matches the id from wallpostdbcontext to the currently logged in id 
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
        //gets id for the currently logged in user 
        //finds where the receiver id and the user id matches and the accepted equals true and adds it to a list
        //also where the sender id and the user id matches and adds it to a lsit
        public ActionResult ProfilePage()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var ctx = new ApplicationDbContext();

            var requests = ctx.FriendRequests.Where(x => x.Reciever == currentUser.Id && x.Accepted == true).ToList();
            var requests2 = ctx.FriendRequests.Where(x => x.Sender == currentUser.Id && x.Accepted == true).ToList();
            var friends = new List<ApplicationUser>();
            foreach (var request in requests)
            {
                var user = ctx.Users.FirstOrDefault(x => x.Id == request.Sender);

                friends.Add(user);

                
            }

            foreach (var request in requests2)
            {
                var user2 = ctx.Users.FirstOrDefault(x => x.Id == request.Reciever);

                friends.Add(user2);


            }

            return View(new ProfileViewModel
            {
                Friends = friends,
                User = currentUser
            });
        }
        
        


    }
}