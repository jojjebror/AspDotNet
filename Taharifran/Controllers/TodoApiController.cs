using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taharifran.Models;

namespace Taharifran.Controllers
{
    [RoutePrefix("api/todos")]
    public class TodoApiController : ApiController
    {

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

        [Route("friendrequests/add")]
        [HttpPost]
        public IHttpActionResult AddFriendRequest(string sender, string reciever)
        {
            try
            {
                var ctx = new ApplicationDbContext();

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


        [Route("acceptrequest")]
        [HttpPost]
        public IHttpActionResult AcceptFriendRequest(string sender, string reciever)
        {
            try
            {
                var ctx = new ApplicationDbContext();

                //ctx.FriendRequests.Add(new FriendRequest
                //{
                //    Reciever = reciever,
                //    Sender = sender,
                //    Date = DateTime.Now
                //});

                ctx.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [Route("friendrequests")]
        [HttpGet]
        public IHttpActionResult GetFriendRequestById(string userId)
        {
            try
            {
                var ctx = new ApplicationDbContext();
                var requests = ctx.FriendRequests.Where(x => x.Reciever == userId);

                return Json(requests.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
