using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trepapp.Startup))]
namespace Trepapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
