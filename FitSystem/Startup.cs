using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitSystem.Startup))]
namespace FitSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
