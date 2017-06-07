using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webNew3.Startup))]
namespace webNew3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
