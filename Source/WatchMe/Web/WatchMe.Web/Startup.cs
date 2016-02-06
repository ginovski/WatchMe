using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WatchMe.Web.Startup))]
namespace WatchMe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
