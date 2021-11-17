using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(JardinesEF.Web.Startup))]
namespace JardinesEF.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
