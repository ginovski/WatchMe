namespace WatchMe.Web.Controllers
{
    using Infastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Actors;
    using ViewModels.Categories;

    public class SearchController : Controller
    {
        private ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public ActionResult Index(string query)
        {
            ViewBag.Query = query;
            return View();
        }

        [ChildActionOnly]
        public ActionResult Movies(string query)
        {
            var movies = this.searchService.Movies(query).To<CategoryMovieViewModel>().ToList();

            return PartialView("Partials/_SearchMoviesPartial", movies);
        }

        [ChildActionOnly]
        public ActionResult Actors(string query)
        {
            var actors = this.searchService.Actors(query).To<ActorsListViewModel>().ToList();

            return View("Partials/_SearchActorsPartial", actors);
        }
    }
}