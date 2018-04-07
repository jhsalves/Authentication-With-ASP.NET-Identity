using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailIdentity.Startup))]
namespace EmailIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
