namespace WatchMe.Web.Controllers
{
    using System.Web.Mvc;
    using WatchMe.Web.Controllers.Base;

    public class ErrorController : BaseController
    {
        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult Forbidden()
        {
            return this.View();
        }

        public ActionResult InternalServerError()
        {
            return this.View();
        }
    }
}