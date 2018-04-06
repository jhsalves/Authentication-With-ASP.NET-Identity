using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTour.Startup))]
namespace IdentityTour
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
