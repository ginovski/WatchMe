namespace WatchMe.Web.Controllers
{
    using Base;
    using Infastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Home;
    public class HomeController : BaseController
    {
        private IMoviesService moviesService;
        private ICategoriesService categoriesService;

        public HomeController(IMoviesService moviesService, ICategoriesService categoriesService)
        {
            this.moviesService = moviesService;
            this.categoriesService = categoriesService;
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

        [OutputCache(Duration = 2 * 60 * 60)]
        [ChildActionOnly]
        public ActionResult AllCategories()
        {
            var allCategories = this.categoriesService.AllCategories().To<CategoryViewModel>().ToList();

            return PartialView("Partials/_AllCategoriesPartial", allCategories);
        }
    }
}