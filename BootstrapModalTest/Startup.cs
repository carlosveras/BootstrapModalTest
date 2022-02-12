using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootstrapModalTest.Startup))]
namespace BootstrapModalTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
