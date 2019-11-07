using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAS.CursMvc.Ui.Site.Startup))]
namespace RAS.CursMvc.Ui.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
