namespace WatchMe.Services.Data.Contracts
{
    using System.Linq;
    using WatchMe.Data.Models;
    using WatchMe.Services.Common;

    public interface IUsersService : IService
    {
        IQueryable<User> GetUserById(string id);

        void ChangeMovieStatus(string movieId, int statusNumber, string userId);

        IQueryable<UserMovie> GetUserMovies(string userId);
    }
}