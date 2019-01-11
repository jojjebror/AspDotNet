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

       
    }
}
