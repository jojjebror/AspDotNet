using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Taharifran.Models
{
    public class WallItem
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }
        public bool IsDone { get; set; }


        public int TodoListId { get; set; }

        public virtual WallPost WallPost { get; set; }
    }

    public class WallPost
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserId { get; set; }

        

        public virtual ICollection<WallItem> WallItems { get; set; }

        public WallPost()
        {
            WallItems = new HashSet<WallItem>();
        }


    }
    public class WallPostDbContext : DbContext
    {
        public DbSet<WallItem> WallItem { get; set; }
        public DbSet<WallPost> WallPostList { get; set; }
        public WallPostDbContext() : base("TodoDb") { }
    }
}