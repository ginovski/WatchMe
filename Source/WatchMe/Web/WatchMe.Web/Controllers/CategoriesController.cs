namespace WatchMe.Web.Controllers
{
    using Base;
    using Infastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Categories;
    using ViewModels.Home;

    public class CategoriesController : BaseController
    {
        private const int PageSize = 5;

        private IMoviesService moviesService;
        private ICategoriesService categoriesService;

        public CategoriesController(IMoviesService moviesService, ICategoriesService categoriesService)
        {
            this.moviesService = moviesService;
            this.categoriesService = categoriesService;
        }

        [OutputCache(Duration = 2 * 60 * 60)]
        [ChildActionOnly]
        public ActionResult All()
        {
            var allCategories = this.categoriesService.AllCategories().To<CategoryViewModel>().ToList();

            return PartialView("Partials/_SidebarAllCategories", allCategories);
        }

        public ActionResult Index()
        {
            return RedirectToActionPermanent("Details");
        }

        public ActionResult Details(string id, int page = 1)
        {
            var count = this.moviesService.MoviesInCategoryCount(id);
            ViewBag.Count = (count / PageSize) + 1;
            ViewBag.Page = page;
            TempData["CategoryIdentifier"] = id;

            var moviesInCategory = this.moviesService.MoviesInCategory(id, page - 1, PageSize).To<CategoryMovieViewModel>().ToList();
            return View(moviesInCategory);
        }
    }
}