using System;
using Systrade.Eventos.Domain.Entidades.AgenciaUsuarioEvents;

namespace Systrade.Eventos.Domain.Entidades.Repository.Service
{
    public interface IUsuarioEventService
    {
        UsuarioEvents AdicionarAgenciaUsuarioEvent(UsuarioEvents usuarioEvent);
        UsuarioEvents BuscarAgenciaUsuarioEventPorId(Guid Id);
    }
}
