using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Systrade.Cadastro.UI.Mvc.Startup))]
namespace Systrade.Cadastro.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
