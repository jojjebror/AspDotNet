using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taharifran.Models
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public List<ApplicationUser> Friends { get; set; }
    }

    
}