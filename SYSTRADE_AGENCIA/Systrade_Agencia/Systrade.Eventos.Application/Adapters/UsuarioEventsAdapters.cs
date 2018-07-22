using Systrade.Eventos.Application.ViewModel;
using Systrade.Eventos.Domain.Entidades.AgenciaUsuarioEvents;

namespace Systrade.Eventos.Application.Adapters
{
    public class UsuarioEventsAdapters
    {
        public static UsuarioEvents ToDomainModel(UsuarioEventViewModel model)
        {
            var usuarioevent = new UsuarioEvents(
                model.LogadoId,
                model.ModificadoId,
                model.Logado,
                model.Modificado,
                model.Permissao,
                model.Menssagem
                );

            return usuarioevent;
        }
    }
}
