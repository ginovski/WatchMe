namespace WatchMe.Web.Controllers.Base
{
    using AutoMapper;
    using Data.Models;
    using Ninject;
    using Services.Web.Contracts;
    using System.Web.Mvc;
    using WatchMe.Web.Infastructure.Mapping;

    public class BaseController : Controller
    {
        [Inject]  
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}