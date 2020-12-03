using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacturacionMVC.Startup))]
namespace FacturacionMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
