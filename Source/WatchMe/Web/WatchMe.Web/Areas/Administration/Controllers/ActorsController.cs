namespace WatchMe.Web.Areas.Administration.Controllers
{
    using Infastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using ViewModels.Actors;
    using WatchMe.Web.Areas.Administration.Controllers.Base;

    public class ActorsController : BaseAdministrationController
    {
        private IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var posts = this.actorsService
                .AllActors()
                .To<ActorViewModel>()
                .ToDataSourceResult(request);

            return this.Json(posts);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ActorViewModel model)
        {
            this.actorsService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ActorViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var actor = this.actorsService.GetById(model.Id);
                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;

                this.actorsService.Update(actor);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}