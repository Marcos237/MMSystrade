using SimpleInjector;
using Systrade.Clientes.Applications.Interfaces;
using Systrade.Clientes.Applications.Services;
using Systrade.Clientes.Domain.Intefaces.Repository;
using Systrade.Clientes.Domain.Intefaces.Services;
using Systrade.Clientes.Infra.Data.Context;
using Systrade.Clientes.Infra.Data.Interfaces;
using Systrade.Clientes.Infra.Data.Repository;
using Systrade.Clientes.Infra.Data.Uow;

namespace Systrade.Clientes.CrossCutting
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            MyContainer = container;

            //APP
            container.Register<IClienteAppService, ClienteAppService>();


            //Dominio
            container.Register<IClienteService, ClienteService>();


            //Infra Dados
            container.Register<SystradeClientesContext>(Lifestyle.Scoped);
            container.Register<ICelulaRepository, CelulaRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);


            // Handlers

        }
    }
}
