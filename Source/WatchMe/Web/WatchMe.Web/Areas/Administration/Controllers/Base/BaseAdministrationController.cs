namespace WatchMe.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;
    using WatchMe.Web.Controllers.Base;

    [Authorize(Roles = "Admin")]
    public class BaseAdministrationController : BaseController
    {
    }
}