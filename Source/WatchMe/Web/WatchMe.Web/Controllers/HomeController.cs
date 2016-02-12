namespace WatchMe.Web.Controllers
{
    using Infastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Home;
    public class HomeController : Controller
    {
        private IMoviesService moviesService;

        public HomeController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [ChildActionOnly]
        public ActionResult LatestMovies()
        {
            var latestThreeMovies = this.moviesService
                .LatestReleasedMovies(3)
                .To<LatestMoviesViewModel>()
                .ToList();

            return PartialView("Partials/_LatestMoviesPartial", latestThreeMovies);
        }
    }
}