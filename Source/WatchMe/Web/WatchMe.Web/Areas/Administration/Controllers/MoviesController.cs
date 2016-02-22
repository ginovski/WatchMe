namespace WatchMe.Web.Areas.Administration.Controllers
{
    using Infastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using ViewModels.Movies;
    using WatchMe.Web.Areas.Administration.Controllers.Base;

    public class MoviesController : BaseAdministrationController
    {
        private IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var posts = this.moviesService
                .AllMovies()
                .To<MovieViewModel>()
                .ToDataSourceResult(request);

            return this.Json(posts);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, MovieViewModel model)
        {
            this.moviesService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, MovieViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var movie = this.moviesService.GetById(model.Id);
                movie.Title = model.Title;
                movie.Overview = model.Overview;
                movie.Duration = model.Duration;
                movie.ReleaseDate = model.ReleaseDate;

                this.moviesService.Update(movie);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}