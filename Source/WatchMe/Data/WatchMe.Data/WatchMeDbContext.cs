namespace WatchMe.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Contracts;
    using Models;
    using Migrations;

    public class WatchMeDbContext : IdentityDbContext<User>, IWatchMeDbContext
    {
        public WatchMeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WatchMeDbContext, Configuration>());
        }

        public static WatchMeDbContext Create()
        {
            return new WatchMeDbContext();
        }
    }
}
