namespace WatchMe.Web.Areas.Administration.Controllers
{
    using Base;
    using Infastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Reviews;

    public class ReviewsController : BaseAdministrationController
    {
        private IReviewsService reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        public ActionResult Index()
        {
            var allFlagged = this.reviewsService
                .GetAllFlagged()
                .To<ReviewViewModel>()
                .ToList();

            return View(allFlagged);
        }

        [HttpPost]
        public ActionResult Accept(int id)
        {
            if (Request.IsAjaxRequest())
            {
                this.reviewsService.Accept(id);
            }

            var all = this.reviewsService
                .GetAllFlagged()
                .To<ReviewViewModel>()
                .ToList();

            return this.PartialView("Partials/_ReviewsPartial", all);
        }

        [HttpPost]
        public ActionResult Deny(int id)
        {
            if (Request.IsAjaxRequest())
            {
                this.reviewsService.Deny(id);
            }

            var all = this.reviewsService
                .GetAllFlagged()
                .To<ReviewViewModel>()
                .ToList();

            return this.PartialView("Partials/_ReviewsPartial", all);
        }
    }
}