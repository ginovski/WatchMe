namespace WatchMe.Web.Areas.Administration.Controllers
{
    using Base;
    using System.Web.Mvc;

    public class CategoriesController : BaseAdministrationController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}