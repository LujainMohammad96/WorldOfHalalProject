using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldOfHalalWebUI.Startup))]
namespace WorldOfHalalWebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
