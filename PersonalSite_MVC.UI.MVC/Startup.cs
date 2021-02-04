using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalSite_MVC.UI.MVC.Startup))]
namespace PersonalSite_MVC.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
