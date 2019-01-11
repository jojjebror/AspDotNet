using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Taharifran.Models
{//ta bort hela klassen todoitem?
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }
        public bool IsDone { get; set; }

        // Vi skapar en främmande nyckel
        public int TodoListId { get; set; }
        // och säger att den ska referera till TodoList
        public virtual TodoList TodoList { get; set; }
    }
    //byt namn på klass
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserId { get; set; }

        //ta bort icollection och todolist nedanför?
        
        public virtual ICollection<TodoItem> TodoItems { get; set; }

        public TodoList()
        {
            TodoItems = new HashSet<TodoItem>();
        }

        
    }
    //byt namn på tododbcontext och listan under 
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        

        public TodoDbContext() : base("TodoDb") { }
    }
}