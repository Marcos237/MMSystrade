using System;
using Systrade.Eventos.Domain.Entidades.AgenciaUsuarioEvents;

namespace Systrade.Eventos.Application.Interfaces
{
    public interface IUsuarioEventAppService
    {
        UsuarioEvents BuscarAgenciaUsuarioEventPorId(Guid Id);

    }
}
