using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobPortal.Web.Startup))]
namespace JobPortal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
