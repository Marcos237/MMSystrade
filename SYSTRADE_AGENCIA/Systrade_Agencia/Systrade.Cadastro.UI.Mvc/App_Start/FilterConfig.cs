using SimpleInjector;
using System.Web.Mvc;
using Systrade.CrossCutting.Filters;

namespace Systrade.Cadastro.UI.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(container.GetInstance<GlobalFilterTool>());
        }
    }
}
