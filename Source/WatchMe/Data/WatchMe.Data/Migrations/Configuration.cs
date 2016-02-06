namespace WatchMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Common;
    using Models;

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
            this.SeedActors(context);
            this.SeedDirectors(context);
        }
        
        private void SeedActors(WatchMeDbContext context)
        {
            if (context.Actors.Any())
            {
                return;
            }

            for (int i = 0; i < 20; i++)
            {
                var newActor = new Actor
                {
                    FirstName = RandomDataGenerator.Instance.GetRandomString(3, 15),
                    LastName = RandomDataGenerator.Instance.GetRandomString(3, 15),
                    Rating = new Rating
                    {
                        Value = RandomDataGenerator.Instance.GetRandomInt(0, 5)
                    }
                };

                context.Actors.Add(newActor);
            }

            context.SaveChanges();
        }

        private void SeedDirectors(WatchMeDbContext context)
        {
            if (context.Directors.Any())
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var newDirector = new Director
                {
                    FirstName = RandomDataGenerator.Instance.GetRandomString(3, 15),
                    LastName = RandomDataGenerator.Instance.GetRandomString(3, 15),
                    Rating = new Rating
                    {
                        Value = RandomDataGenerator.Instance.GetRandomInt(0, 5)
                    }
                };

                context.Directors.Add(newDirector);
            }

            context.SaveChanges();
        }
    }
}
