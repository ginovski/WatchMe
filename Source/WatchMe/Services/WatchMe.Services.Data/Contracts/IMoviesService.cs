namespace WatchMe.Services.Data.Contracts
{
    using System.Linq;
    using WatchMe.Data.Models;

    public interface IMoviesService : IService
    {
        IQueryable<Movie> LatestReleasedMovies(int count);
    }
}
