using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OAuth.Web.Startup))]
namespace OAuth.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
