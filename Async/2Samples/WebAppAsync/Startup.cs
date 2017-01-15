using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppAsync.Startup))]
namespace WebAppAsync
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
