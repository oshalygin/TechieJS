using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TN.Web.Startup))]
namespace TN.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
