using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinanzasPersonales.Startup))]
namespace FinanzasPersonales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
