using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarAdvertsSystem.WebFormsClient.Startup))]
namespace CarAdvertsSystem.WebFormsClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
