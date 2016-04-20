using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HvisaoApp.Startup))]
namespace HvisaoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
