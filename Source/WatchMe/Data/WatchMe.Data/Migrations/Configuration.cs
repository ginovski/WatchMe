namespace WatchMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Common;
    using Models;
    using Tools;

    public sealed class Configuration : DbMigrationsConfiguration<WatchMeDbContext>
    {
        public Configuration()
        {
            // TODO: When production must be false
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = false;
            ContextKey = "WatchMe.Data.WatchMeDbContext";
        }

        protected override void Seed(WatchMeDbContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            var fetcher = new MoviesFetcher();

            fetcher.FetchMovies(context, 5);
        }
    }
}
