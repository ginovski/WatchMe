namespace WatchMe.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class WatchMeDbContext : IdentityDbContext<User>
    {
        public WatchMeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static WatchMeDbContext Create()
        {
            return new WatchMeDbContext();
        }
    }
}
