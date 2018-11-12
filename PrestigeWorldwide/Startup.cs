using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrestigeWorldwide.Startup))]
namespace PrestigeWorldwide
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
