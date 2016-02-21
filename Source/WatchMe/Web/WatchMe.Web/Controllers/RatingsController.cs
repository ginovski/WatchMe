namespace WatchMe.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using WatchMe.Web.Controllers.Base;

    [Authorize]
    public class RatingsController : BaseController
    {
        private IRatingsService ratingsService;

        public RatingsController(IRatingsService ratingsService)
        {
            this.ratingsService = ratingsService;
        }

        public ActionResult Movies(string id, int rateValue)
        {
            var userId = this.User.Identity.GetUserId();

            var newAverage = this.ratingsService.RateMovie(id, rateValue, userId);

            return this.Json(new {
                rating = newAverage
            });
        }
    }
}