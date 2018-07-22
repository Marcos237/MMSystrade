using System;
using Systrade.Eventos.Domain.Entidades.AgenciaUsuarioEvents;
using Systrade.Eventos.Domain.Entidades.Repository;
using Systrade.Eventos.Domain.Entidades.Repository.Service;

namespace Systrade.Eventos.Domain.Services
{
    public class UsuarioEventService : IUsuarioEventService
    {
        private readonly IUsuarioEventRepository _usuarioeventrepository;

        public UsuarioEventService(IUsuarioEventRepository usuarioeventrepository)
        {
            _usuarioeventrepository = usuarioeventrepository;
        }

        public UsuarioEvents AdicionarAgenciaUsuarioEvent(UsuarioEvents usuarioEvent)
        {
            return _usuarioeventrepository.AdicionarUsuarioEvents(usuarioEvent);
        }

        public UsuarioEvents BuscarAgenciaUsuarioEventPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _usuarioeventrepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
