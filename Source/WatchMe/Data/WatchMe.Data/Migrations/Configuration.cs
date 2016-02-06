namespace WatchMe.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WatchMeDbContext>
    {
        public Configuration()
        {
            // TODO: When production must be false
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "WatchMe.Data.WatchMeDbContext";
        }

        protected override void Seed(WatchMeDbContext context)
        {
        }
    }
}
