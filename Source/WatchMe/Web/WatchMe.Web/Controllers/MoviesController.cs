namespace WatchMe.Web.Controllers
{
    using System.Web.Mvc;

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
            return View();
        }
    }
}