using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Systrade.Cadastro.Mvc.UI.Startup))]
namespace Systrade.Cadastro.Mvc.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
