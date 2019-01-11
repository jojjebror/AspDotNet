using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taharifran.Models
{
    public class UserIndexViewModel
    {//ändra namn på listorna 
        public List<User> Users { get; set; }
        public string UserId { get; set; }
        public List<TodoList> TodoLists { get; set; }
       
        
        public TodoList List { get; set; }

    }

    
}