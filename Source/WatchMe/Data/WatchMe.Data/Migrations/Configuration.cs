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
            this.SeedCategories(context);
            this.SeedMovies(context);
        }

        private void SeedCategories(WatchMeDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            for (int i = 0; i < 5; i++)
            {
                var newCategory = new Category
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(5, 10)
                };

                context.Categories.Add(newCategory);
            }

            context.SaveChanges();
        }

        private void SeedMovies(WatchMeDbContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            var directors = context.Directors.Take(10).ToList();
            var actors = context.Actors.Take(20).ToList();
            var categories = context.Categories.Take(5).ToList();

            int actorIndex = 0;
            int categoryIndex = 0;

            for (int i = 0; i < 10; i++)
            {
                var newMovie = new Movie
                {
                    Title = RandomDataGenerator.Instance.GetRandomString(5, 15),
                    Duration = RandomDataGenerator.Instance.GetRandomInt(60, 120),
                    IMDBLink = RandomDataGenerator.Instance.GetRandomString(20, 30),
                    Rating = new Rating
                    {
                        Value = RandomDataGenerator.Instance.GetRandomInt(0, 5)
                    },
                    ReleaseDate = RandomDataGenerator.Instance
                    .GetRandomDate(DateTime.Now.AddYears(-10), DateTime.Now.AddYears(-1)),
                    DirectorId = directors[i].Id
                };

                for (int j = 0; j < 2; j++)
                {
                    newMovie.Cast.Add(actors[actorIndex]);
                    actorIndex++;
                }

                newMovie.Categories.Add(categories[categoryIndex]);

                if (i % 2 != 0)
                {
                    categoryIndex++;
                }

                context.Movies.Add(newMovie);
            }

            context.SaveChanges();
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
