using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Personnel.Startup))]
namespace Personnel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
