using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WApp.Startup))]
namespace WApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
