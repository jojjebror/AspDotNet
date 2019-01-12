using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Taharifran.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public byte [] UserPhoto { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

       

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
           
            return userIdentity;
        }
    }


    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }

        public string Reciever { get; set; }
        public string Sender { get; set; }
        public DateTime Date { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

       
        public DbSet<FriendRequest> FriendRequests { get; set; }

        public static ApplicationDbContext Create() 
        {
            return new ApplicationDbContext();
        }
    }
}