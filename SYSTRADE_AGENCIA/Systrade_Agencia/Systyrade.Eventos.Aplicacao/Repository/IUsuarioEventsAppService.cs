using System;
using Systrade.Eventos.Aplicacao.ViewModel;
using Systrade.Events.Dominio.Entidades;
using Systyrade.Eventos.Aplicacao.ViewModel;

namespace Systyrade.Eventos.Aplicacao.Repository
{
    public interface IUsuarioEventsAppService
    {
        UsuarioEvents AdicionarUsuarioEvent(UsuarioEvents usuario);
        PagedEventsViewModel<UsuarioEventsViewModel> BuscarUsuarioEventos(Guid Id);
    }
}
