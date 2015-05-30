
using Utils.Authentication;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_xam.Startup))]
namespace E_xam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            StartupAuth.ConfigureAuth(app);

        }
    }
}
