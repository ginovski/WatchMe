namespace WatchMe.Services.Data.Contracts
{
    using System.Linq;
    using WatchMe.Data.Models;
    using WatchMe.Services.Common;

    public interface ISearchService : IService
    {
        IQueryable<Movie> Movies(string query);

        IQueryable<Actor> Actors(string query);
    }
}
