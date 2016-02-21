namespace WatchMe.Web.Controllers
{
    using System.Web.Mvc;

    using ViewModels.Movies;
    using Infastructure.Mapping;
    using WatchMe.Services.Data.Contracts;
    using System.Linq;
    using System.Diagnostics;
    using Base;
    using Microsoft.AspNet.Identity;
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
            var movieState = this.moviesService.GetMovieStateForCurrentUser(id, this.User.Identity.GetUserId());
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