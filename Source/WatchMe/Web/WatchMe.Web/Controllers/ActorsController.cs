namespace WatchMe.Web.Controllers
{
    using Infastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Actors;
    public class ActorsController : Controller
    {
        private IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        public ActionResult Details(int id)
        {
            var actor = this.actorsService.ActorById(id)
                .To<ActorDetailsViewModel>()
                .FirstOrDefault();

            return this.View(actor);
        }
    }
}