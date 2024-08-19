using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLacome.Startup))]
namespace WebLacome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
