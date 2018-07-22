using AutoMapper;
using System;
using System.Collections.Generic;
using Systrade.Eventos.Aplicacao.ViewModel;
using Systrade.Events.Dominio.Entidades;
using Systrade.Events.Dominio.Repository;
using Systyrade.Eventos.Aplicacao.Repository;
using Systyrade.Eventos.Aplicacao.ViewModel;

namespace Systyrade.Eventos.Aplicacao.Servicos
{
    public class UsuarioEventsAppService : IUsuarioEventsAppService
    {
        private readonly IUsuarioEventRepository _usuarioevent;

        public UsuarioEventsAppService(IUsuarioEventRepository usuarioEvent)
        {
            _usuarioevent = usuarioEvent;
        }
        public UsuarioEvents AdicionarUsuarioEvent(UsuarioEvents usuario)
        {
           return  _usuarioevent.AdicionarUsuarioEvent(usuario);
        }

        public PagedEventsViewModel<UsuarioEventsViewModel> BuscarUsuarioEventos(Guid Id)
        {
            var result = Mapper.Map<PagedEventsViewModel<UsuarioEventsViewModel>>(_usuarioevent.BuscarUsuarioEvent(Id));
            return result;
        }
    }
}
