namespace WatchMe.Web.Controllers
{
    using System.Web.Mvc;

    using ViewModels.Movies;
    using Infastructure.Mapping;
    using WatchMe.Services.Data.Contracts;

    public class MoviesController : BaseController
    {
        private IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public ActionResult Details(string id)
        {
            var movie = this.moviesService.MovieById(id);
            var viewModel = this.Mapper.Map<MovieViewModel>(movie);

            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult DailyMovie()
        {
            var dailyMovie = this.Cache.Get(
                    "dailyMovie",
                    () =>
                    {
                        return this.Mapper.Map<DailyMovieViewModel>(this.moviesService.GetDailyMovie());
                    },
                    24 * 60 * 60);

            return PartialView("Partials/_SidebarDailyMovie", dailyMovie);
        }
    }
}