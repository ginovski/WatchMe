namespace WatchMe.Web.Controllers
{
    using Infastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Users;
    using WatchMe.Web.Controllers.Base;

    [Authorize]
    public class UsersController : BaseController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult WishList()
        {
            var userMovies = this.usersService
                .GetUserMovies(this.User.Identity.GetUserId())
                .To<UserMovieViewModel>()
                .ToList();

            return View(userMovies);
        }
    }
}