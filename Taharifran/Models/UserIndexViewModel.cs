using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taharifran.Models
{
    public class UserIndexViewModel
    {
        public string UserId { get; set; }

        public List<WallPost> WallPostList { get; set; }
       
        public WallPost List { get; set; }

    }

    
}