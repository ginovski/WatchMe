namespace WatchMe.Data.Tools
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Adapters;
    using Contracts;
    using Models;

    using TMDbLib.Objects.Movies;

    public class MoviesFetcher
    {
        private const string ImdbTitleUrl = "http://www.imdb.com/title/";
        private const string BaseImageUrl = "https://image.tmdb.org/t/p/w185";

        private ITMDbClientAdapter client;
        private IWebClientAdapter webClient;

        public MoviesFetcher(ITMDbClientAdapter client, IWebClientAdapter webClient)
        {
            this.client = client;
            this.webClient = webClient;
        }

        public MoviesFetcher()
            : this(new TMDbClientAdapter(), new WebClientAdapter())
        {
        }

        public void FetchMovies(IWatchMeDbContext db, int pagesOfTwenty = 1)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string directory = Path.GetDirectoryName(path).Substring(0, Path.GetDirectoryName(path).LastIndexOf('\\'));

            if (!db.Categories.Any())
            {
                var genres = client.GetMovieGenres();
                foreach (var genre in genres)
                {
                    var newCategory = new Category()
                    {
                        Name = genre.Name,
                        CategoryIdentifier = string.Join("-", genre.Name.ToLower().Split(' '))
                    };

                    db.Categories.Add(newCategory);
                }

                db.SaveChanges();
            }

            if (!db.Movies.Any())
            {
                for (int i = 1; i <= pagesOfTwenty; i++)
                {
                    var mostPopularMovies = client.GetMovieList(MovieListType.Popular, i).Results;
                    foreach (var movieItem in mostPopularMovies)
                    {
                        var movie = client.GetMovie(movieItem.Id, MovieMethods.Credits);
                        var director = movie.Credits.Crew.FirstOrDefault(c => c.Job == "Director");
                        using (webClient)
                        {
                            if (movie.PosterPath != null)
                            {
                                webClient.DownloadFile(BaseImageUrl + movie.PosterPath, directory + "\\Images\\Movies\\" + movie.PosterPath);
                            }
                            if (director.ProfilePath != null)
                            {
                                webClient.DownloadFile(BaseImageUrl + director.ProfilePath, directory + "\\Images\\Directors\\" + director.ProfilePath);
                            }
                        }
                        var dbMovie = new Models.Movie()
                        {
                            Title = movie.OriginalTitle,
                            ReleaseDate = movie.ReleaseDate,
                            Duration = movie.Runtime,
                            Rating = new Rating(),
                            IMDBLink = ImdbTitleUrl + movie.ImdbId,
                            Director = new Director()
                            {
                                FirstName = director.Name.Split(' ')[0],
                                LastName = director.Name.Split(' ')[1],
                                ProfileImage = director.ProfilePath != null ? new Image() { Path = director.ProfilePath } : null,
                                Rating = new Rating()
                            },
                            CoverImage = movie.PosterPath != null ? new Image() { Path = movie.PosterPath } : null
                        };


                        foreach (var actor in movie.Credits.Cast)
                        {
                            using (webClient)
                            {
                                if (actor.ProfilePath != null)
                                {
                                    webClient.DownloadFile(BaseImageUrl + actor.ProfilePath, directory + "\\Images\\Actors\\" + actor.ProfilePath);
                                }
                            }

                            var imageUrl = BaseImageUrl + actor.ProfilePath;
                            var names = actor.Name.Split(' ');
                            var firstName = string.Empty;
                            var lastName = string.Empty;
                            if (names.Length == 2)
                            {
                                firstName = names[0];
                                lastName = names[1];
                            }
                            else
                            {
                                firstName = actor.Name;
                            }

                            var dbActor = db.Actors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);

                            if (dbActor == null)
                            {
                                dbActor = new Actor()
                                {
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Rating = new Rating(),
                                    ProfileImage = actor.ProfilePath != null ? new Image() { Path = actor.ProfilePath } : null
                                };

                                db.Actors.Add(dbActor);
                                db.SaveChanges();
                            }

                            dbMovie.Cast.Add(dbActor);
                        }

                        db.SaveChanges();

                        foreach (var category in movie.Genres)
                        {
                            var dbCategory = db.Categories.FirstOrDefault(c => c.Name == category.Name);
                            dbMovie.Categories.Add(dbCategory);
                        }

                        db.Movies.Add(dbMovie);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
