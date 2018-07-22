using System;
using Systrade.Events.Dominio.DTO;
using Systrade.Events.Dominio.Entidades;

namespace Systrade.Events.Dominio.Repository
{
    public interface IUsuarioEventRepository
    {
        UsuarioEvents AdicionarUsuarioEvent(UsuarioEvents usuario);
        PagedEvent<UsuarioEvents> BuscarUsuarioEvent(Guid Id);
    }
}
