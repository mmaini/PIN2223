using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EF_Login.Startup))]
namespace EF_Login
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
