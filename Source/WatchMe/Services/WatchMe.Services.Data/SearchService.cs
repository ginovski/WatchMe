namespace WatchMe.Services.Data
{
    using System.Linq;
    using WatchMe.Data.Contracts;
    using WatchMe.Data.Models;
    using WatchMe.Services.Data.Contracts;

    public class SearchService : ISearchService
    {
        private IRepository<Movie> movies;
        private IRepository<Actor> actors;

        public SearchService(IRepository<Movie> movies, IRepository<Actor> actors)
        {
            this.movies = movies;
            this.actors = actors;
        }

        public IQueryable<Actor> Actors(string query)
        {
            var actors = this.actors.All().Where(a => a.FirstName.Contains(query) || a.LastName.Contains(query));

            return actors;
        }

        public IQueryable<Movie> Movies(string query)
        {
            var movies = this.movies.All().Where(m => m.Title.Contains(query));

            return movies;
        }
    }
}