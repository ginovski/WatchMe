namespace WatchMe.Web.Areas.Administration.Controllers
{
    using Base;
    using Infastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using ViewModels.Categories;
    public class CategoriesController : BaseAdministrationController
    {
        private ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var posts = this.categoriesService
                .AllCategories()
                .To<CategoryViewModel>()
                .ToDataSourceResult(request);

            return this.Json(posts);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            this.categoriesService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.categoriesService.GetById(model.Id);
                category.Name = model.Name;
                category.CategoryIdentifier = model.CategoryIdentifier;

                this.categoriesService.Update(category);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}