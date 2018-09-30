using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TamilRockers.Startup))]
namespace TamilRockers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
