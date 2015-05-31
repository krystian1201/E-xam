
using E_xam;
using Microsoft.Owin;
using Owin;
using Utils.Authentication;

[assembly: OwinStartup(typeof(Startup))]
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
