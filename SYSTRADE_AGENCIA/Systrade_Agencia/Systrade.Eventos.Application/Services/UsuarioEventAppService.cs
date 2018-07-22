using System;
using Systrade.Eventos.Application.Interfaces;
using Systrade.Eventos.Domain.Entidades.AgenciaUsuarioEvents;
using Systrade.Eventos.Domain.Entidades.Repository.Service;

namespace Systrade.Eventos.Application.Services
{
    public class UsuarioEventAppService : IUsuarioEventAppService
    {
        private readonly IUsuarioEventService _usuarioeventservice;
        public UsuarioEventAppService(IUsuarioEventService usuarioeventservice)
        {
            _usuarioeventservice = usuarioeventservice;
        }

        public UsuarioEvents BuscarAgenciaUsuarioEventPorId(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
