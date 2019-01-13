using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taharifran.Models;

namespace Taharifran.Controllers
{

    //sets the api controller routeprefix 
    [RoutePrefix("api/controller")]
    public class ApiController : System.Web.Http.ApiController
    {
        //takes in two parameters, user id and name (which is what the user enters in the textfield while posting a wallpost)
        //Adds the values into a list and saves the changes
        [Route("list/add")]
        [HttpGet]
        public void AddPost(string userId, string name)
        {
            var ctx = new WallPostDbContext();
            ctx.WallPostList.Add(new WallPost
            {
                Name = name,
                UserId = userId
            });
            ctx.SaveChanges();
        }

        //if the sender id and the receiver id already exists in the table, return badrequest
        // otherwise add the sender id and the receiver id into a list
        [Route("friendrequests/add")]
        [HttpPost]
        public IHttpActionResult AddFriendRequest(string sender, string reciever)
        {
            try
            {
                var ctx = new ApplicationDbContext();

                if(ctx.FriendRequests.Any(x => x.Sender == sender && x.Reciever == reciever))
                {
                    return BadRequest("Friend request already exist");
                }

                ctx.FriendRequests.Add(new FriendRequest
                {
                    Reciever = reciever,
                    Sender = sender,
                    Date = DateTime.Now
                });

                ctx.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //finds match for the receiver id and the sender id, if its not null, sets the Accepted bool to true
        [Route("acceptrequest")]
        [HttpPost]
        public IHttpActionResult AcceptFriendRequest(string sender, string reciever)
        {
            try
            {
                var ctx = new ApplicationDbContext();

                var friendRequest = ctx.FriendRequests.FirstOrDefault(x => x.Sender == sender && x.Reciever == reciever);

                if (friendRequest != null)
                {
                    friendRequest.Accepted = true;
                }

                ctx.SaveChanges();

                return Json(friendRequest);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //finds where the receiver id and the user id matches and accepted bool is false, "pending friend request"
        [Route("friendrequests")]
        [HttpGet]
        public IHttpActionResult GetFriendRequestById(string userId)
        {
            try
            {
                var ctx = new ApplicationDbContext();
                var requests = ctx.FriendRequests.Where(x => x.Reciever == userId && x.Accepted == false);

                return Json(requests.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
