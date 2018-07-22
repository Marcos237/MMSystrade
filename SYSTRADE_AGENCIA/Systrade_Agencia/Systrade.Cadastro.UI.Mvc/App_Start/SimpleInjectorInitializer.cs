using Microsoft.Owin;
using SimpleInjector.Advanced;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Systrade.Cadastro.UI.Mvc.App_Start;
using Systrade.CrossCutting.Ioc;
using WebActivatorEx;
using Systrade.Core.Events;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace Systrade.Cadastro.UI.Mvc.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.RegisterPerWebRequest(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            });

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // Não utilizar o Verify devido a solicitação dinamica de dependências.
            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            DomainEvent.Container = new DomainEventsContainer(DependencyResolver.Current);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
        }
        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
            Systrade.Clientes.CrossCutting.BootStrapper.Register(container);
        }
    }
}