namespace WatchMe.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        public User()
            : base()
        {
            this.Movies = new HashSet<UserMovie>();
            this.Notifications = new HashSet<Notification>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? ProfileImageId { get; set; }

        public virtual Image ProfileImage { get; set; }

        public virtual ICollection<UserMovie> Movies { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}