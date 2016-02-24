namespace WatchMe.Web.Controllers
{
    using Base;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System;
    using System.Web.Mvc;
    using ViewModels.Reviews;

    public class ReviewsController : BaseController
    {
        private IMoviesService moviesService;
        private IReviewsService reviewsService;

        public ReviewsController(IMoviesService moviesService, IReviewsService reviewsService)
        {
            this.moviesService = moviesService;
            this.reviewsService = reviewsService;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Index(string id)
        {
            ViewBag.MovieId = id;
            return PartialView("Partials/_ReviewFormPartial");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string id, string content)
        {
            if (this.Request.IsAjaxRequest())
            {
                var newReview = new Review
                {
                    Content = content,
                    UserId = this.User.Identity.GetUserId(),
                    DateCreated = DateTime.Now
                };

                this.moviesService.Review(id, newReview);

                var viewModel = this.Mapper.Map<ReviewViewModel>(newReview);
                viewModel.Email = this.User.Identity.GetUserName();

                return this.PartialView("Partials/_ReviewPartial", viewModel);
            }

            return this.RedirectToAction("Details", "Movies", new { id = id });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Flag(int id)
        {
            if (this.Request.IsAjaxRequest())
            {
                this.reviewsService.Flag(id);
            }
            
            return this.Content(string.Empty);
        }
    }
}