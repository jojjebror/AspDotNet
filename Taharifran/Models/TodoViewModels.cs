using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taharifran.Models
{
    //ta bort?

    //public class TodoViewModel
    //{
    //    public string UserId { get; set; }
    //    public List<TodoList> TodoLists { get; set; }
    //}

    public class ListDetailViewModel
    {
        public string UserId { get; set; }
        public TodoList List { get; set; }
    }

}