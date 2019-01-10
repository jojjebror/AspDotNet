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
        // $.get('/api/todos/list/add?userId=NN&name=asdasdas')
        [Route("list/add")]
        [HttpGet]
        public void AddList(string userId, string name)
        {
            var ctx = new TodoDbContext();
            ctx.TodoLists.Add(new TodoList
            {
                Name = name,
                UserId = userId
            });
            ctx.SaveChanges();
        }

       

        // $.get('/api/todos/item/add?listId=NN&text=asdasdas')
        [Route("item/add")]
        [HttpGet]
        public void AddItem(int listId, string text)
        {
            var ctx = new TodoDbContext();
            var list = ctx.TodoLists.FirstOrDefault(l => l.Id == listId);
            if (list != null)
            {
                list.TodoItems.Add(new TodoItem
                {
                    Text = text,
                    TodoListId = listId
                });
                ctx.SaveChanges();
            }
        }

        // $.get('/api/todos/item/toggle?itemId=NN')
        [Route("item/toggle")]
        [HttpGet]
        public void ToggleItem(int itemId)
        {
            var ctx = new TodoDbContext();
            var item = ctx.TodoItems.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.IsDone = !item.IsDone;
                ctx.SaveChanges();
            }
        }
    }
}
