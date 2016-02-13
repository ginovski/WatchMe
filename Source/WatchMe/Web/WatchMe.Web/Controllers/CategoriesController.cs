namespace WatchMe.Web.Controllers
{
    using Infastructure.Mapping;
    using Services.Data;
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private const int PageSize = 5;

        private IMoviesService moviesService;

        public CategoriesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
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
            ViewBag.CategoryIdentifier = id;

            var moviesInCategory = this.moviesService.MoviesInCategory(id, page - 1, PageSize).To<CategoryMovieViewModel>().ToList();
            return View(moviesInCategory);
        }
    }
}