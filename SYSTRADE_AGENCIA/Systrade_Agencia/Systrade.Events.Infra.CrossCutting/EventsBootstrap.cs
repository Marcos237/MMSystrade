using SimpleInjector;
using Systrade.Eventos.Application.Interfaces;
using Systrade.Eventos.Application.Services;
using Systrade.Eventos.Domain.Entidades.Repository;
using Systrade.Eventos.Domain.Entidades.Repository.Service;
using Systrade.Eventos.Domain.Services;
using Systrade.Eventos.Infra.Data.Context;
using Systrade.Eventos.Infra.Data.Repository;

namespace Systrade.Events.Infra.CrossCutting
{
    public class EventsBootstrap
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            MyContainer = container;

            //APP
            container.Register<IUsuarioEventAppService, UsuarioEventAppService>();

            //Dominio
            container.Register<IUsuarioEventService, UsuarioEventService>(Lifestyle.Scoped);

            //Data
            container.Register<IUsuarioEventRepository, UsuarioEventsRepository>(Lifestyle.Scoped);
            container.Register<EventContext>(Lifestyle.Scoped);

        }
    }
}
