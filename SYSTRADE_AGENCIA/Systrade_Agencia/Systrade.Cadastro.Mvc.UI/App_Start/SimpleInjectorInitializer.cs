[assembly: WebActivator.PostApplicationStartMethod(typeof(Systrade.Cadastro.Mvc.UI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Systrade.Cadastro.Mvc.UI.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Systrade.CrossCutting.Ioc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }


        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }
    }
}
