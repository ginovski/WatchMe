namespace WatchMe.Web.Controllers.Base
{
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System;
    using System.Linq;
    using WatchMe.Data.Models;
    using System.Web.Mvc;

    public class BaseAuthorizationController : BaseController
    {
        protected IUsersService usersService;

        public BaseAuthorizationController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public User CurrentUser { get; set; }

        private void SetCurrentUser()
        {
            var userId = this.User.Identity.GetUserId();
            if (userId != null)
            {
                this.CurrentUser = this.usersService.GetUserById(userId).FirstOrDefault();
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.CurrentUser = null;
            }

            if (this.User.Identity.IsAuthenticated && this.CurrentUser == null)
            {
                this.SetCurrentUser();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}