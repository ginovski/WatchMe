namespace WatchMe.Web.Controllers
{
    using System.Web.Mvc;

    public class SearchController : Controller
    {
        public ActionResult Index(string query)
        {

            return View();
        }
    }
}