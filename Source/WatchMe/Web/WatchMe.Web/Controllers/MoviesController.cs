namespace WatchMe.Web.Controllers
{
    using System.Web.Mvc;

    using ViewModels.Movies;
    using Infastructure.Mapping;
    using WatchMe.Services.Data.Contracts;

    public class MoviesController : Controller
    {
        private IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public ActionResult Details(string id)
        {
            var movie = this.moviesService.MovieById(id);
            var mapper = AutoMapperConfig.Configuration.CreateMapper();
            var viewModel = mapper.Map<MovieViewModel>(movie);

            return View(viewModel);
        }
    }
}