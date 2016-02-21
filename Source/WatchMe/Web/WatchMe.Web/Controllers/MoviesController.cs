namespace WatchMe.Web.Controllers
{
    using System.Web.Mvc;

    using ViewModels.Movies;
    using Infastructure.Mapping;
    using WatchMe.Services.Data.Contracts;
    using System.Linq;
    using Base;
    using System.Diagnostics;
    public class MoviesController : BaseAuthorizationController
    {
        private IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService, IUsersService usersService)
            : base(usersService)
        {
            this.moviesService = moviesService;
        }

        public ActionResult Details(string id)
        {
            var movie = this.moviesService.MovieById(id).To<MovieViewModel>().FirstOrDefault();

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
            this.usersService.ChangeMovieStatus(movieId, statusNumber, this.CurrentUser.Id);

            return this.RedirectToAction("Details", new { id = movieId });
        }
    }
}