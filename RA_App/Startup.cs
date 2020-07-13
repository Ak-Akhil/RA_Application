using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RA_App.Startup))]
namespace RA_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
