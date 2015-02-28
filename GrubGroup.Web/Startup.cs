using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrubGroup.Web.Startup))]
namespace GrubGroup.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
