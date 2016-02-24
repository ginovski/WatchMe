namespace WatchMe.Web.Controllers
{
    using Base;
    using Data.Models;
    using Infastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Movies;
    using WatchMe.Services.Data.Contracts;

    public class MoviesController : BaseController
    {
        private IMoviesService moviesService;
        private IUsersService usersService;

        public MoviesController(IMoviesService moviesService, IUsersService usersService)
        {
            this.usersService = usersService;
            this.moviesService = moviesService;
        }

        public ActionResult Details(string id)
        {
            MovieState? movieState = null;
            if (this.User.Identity.IsAuthenticated)
            {
                movieState = this.moviesService.GetMovieStateForCurrentUser(id, this.User.Identity.GetUserId());
            }

            var movie = this.moviesService.MovieById(id).To<MovieViewModel>().FirstOrDefault();
            movie.State = movieState;

            return View(movie);
        }

        [OutputCache(Duration = 24 * 60 * 60)]
        [ChildActionOnly]
        public ActionResult DailyMovie()
        {
            var dailyMovie = this.moviesService.GetDailyMovie().To<DailyMovieViewModel>().FirstOrDefault();

            return PartialView("Partials/_SidebarDailyMovie", dailyMovie);
        }

        [Authorize]
        public ActionResult ChangeStatus(string movieId, int statusNumber)
        {
            this.usersService.ChangeMovieStatus(movieId, statusNumber, this.User.Identity.GetUserId());

            return this.RedirectToAction("Details", new { id = movieId });
        }
    }
}