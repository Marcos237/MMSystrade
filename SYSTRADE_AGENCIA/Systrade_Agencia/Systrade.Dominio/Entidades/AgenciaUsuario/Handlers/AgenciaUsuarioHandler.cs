using System;
using System.Collections.Generic;
using Systrade.Core.Interfaces;
using Systrade.Dominio.Entidades.AgenciaUsuario.Events;
using Systrade.Events.Dominio.Entidades;
using Systrade.Events.Dominio.Repository;

namespace Systrade.Dominio.Entidades.AgenciaUsuario.Handlers
{
    public class AgenciaUsuarioHandler : IHandler<AgenciaUsuarioEvent>
    {
        private List<AgenciaUsuarioEvent> _notifications;

        private readonly IUsuarioEventRepository _usuarioeventrepository;

        public AgenciaUsuarioHandler(IUsuarioEventRepository usuarioeventrepository)
        {
            _usuarioeventrepository = usuarioeventrepository;
        }

        public void Handle(AgenciaUsuarioEvent args)
        {
            var usuarioevent = new UsuarioEvents(
                 args.UsuarioId,
                 args.NomeUsuario,
                 args.UsuarioModificadoId,
                 args.UsuarioModificado,
                 args.CPF,
                 args.ClaimValue,
                 args.Acao,
                 args.DataOcorrencia
                );

            _usuarioeventrepository.AdicionarUsuarioEvent(usuarioevent);
        }

        public IEnumerable<AgenciaUsuarioEvent> Notify()
        {
            return GetValues();
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public List<AgenciaUsuarioEvent> GetValues()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<AgenciaUsuarioEvent>();
        }
    }
}
