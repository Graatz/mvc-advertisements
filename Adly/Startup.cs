using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adly.Startup))]
namespace Adly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
