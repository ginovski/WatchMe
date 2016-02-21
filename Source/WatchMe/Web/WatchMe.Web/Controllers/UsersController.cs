namespace WatchMe.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System.Web.Mvc;
    using WatchMe.Web.Controllers.Base;

    public class UsersController : BaseController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public ActionResult WishList()
        {

            return View();
        }
    }
}