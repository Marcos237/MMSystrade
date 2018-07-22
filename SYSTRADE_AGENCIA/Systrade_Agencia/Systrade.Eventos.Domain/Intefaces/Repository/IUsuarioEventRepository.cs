using System;
using Systrade.Eventos.Domain.Entidades.AgenciaUsuarioEvents;
using Systrade.Eventos.Domain.Intefaces.Repository;

namespace Systrade.Eventos.Domain.Entidades.Repository
{
    public interface IUsuarioEventRepository : IEventRepository<UsuarioEvents>
    {
        UsuarioEvents AdicionarUsuarioEvents(UsuarioEvents usuarioEvents);
        Guid BuscarEventPorId(Guid Id);
    }
}
