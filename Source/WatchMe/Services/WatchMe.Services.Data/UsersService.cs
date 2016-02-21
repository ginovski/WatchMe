namespace WatchMe.Services.Data
{
    using System;
    using System.Linq;
    using WatchMe.Data.Contracts;
    using WatchMe.Data.Models;
    using WatchMe.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;
        private IRepository<UserMovie> userMovies;

        public UsersService(IRepository<User> users, IRepository<UserMovie> userMovies)
        {
            this.userMovies = userMovies;
            this.users = users;
        }

        public void ChangeMovieStatus(string movieId, int statusNumber, string userId)
        {
            var userMovie = this.userMovies.All().Where(m => m.MovieId == movieId && m.UserId == userId).FirstOrDefault();
            if (userMovie == null)
            {
                userMovie = new UserMovie()
                {
                    MovieId = movieId,
                    UserId = userId,
                    State = (MovieState)statusNumber,
                };

                this.userMovies.Add(userMovie);
            }
            else
            {
                userMovie.State = (MovieState)statusNumber;
                this.userMovies.Update(userMovie);
            }

            this.userMovies.SaveChanges();
        }

        public IQueryable<User> GetUserById(string id)
        {
            return this.users
                .All()
                .Where(u => u.Id == id);
        }
    }
}
