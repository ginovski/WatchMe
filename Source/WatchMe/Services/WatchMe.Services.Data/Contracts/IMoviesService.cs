namespace WatchMe.Services.Data.Contracts
{
    using System.Linq;

    using Common;
    using WatchMe.Data.Models;

    public interface IMoviesService : IService
    {
        IQueryable<Movie> LatestReleasedMovies(int count);

        IQueryable<Movie> MoviesInCategory(string id, int page = 0, int pageSize = 10);

        IQueryable<Movie> MovieById(string id);

        int MoviesInCategoryCount(string id);

        IQueryable<Movie> GetDailyMovie();
    }
}
