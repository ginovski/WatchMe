namespace WatchMe.Web.Controllers
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}