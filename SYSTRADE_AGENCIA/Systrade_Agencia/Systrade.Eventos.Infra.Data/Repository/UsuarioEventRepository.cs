using MongoRepository;
using System;
using System.Linq;
using Systrade.Events.Dominio.DTO;
using Systrade.Events.Dominio.Entidades;
using Systrade.Events.Dominio.Repository;

namespace Systrade.Eventos.Infra.Data.Repository
{
    public class UsuarioEventRepository : IUsuarioEventRepository
    {
        MongoRepository<UsuarioEvents> _context = new MongoRepository<UsuarioEvents>();

        public UsuarioEventRepository()
        {

        }
        public UsuarioEvents AdicionarUsuarioEvent(UsuarioEvents usuario)
        {
            return _context.Add(usuario);
        }

        public PagedEvent<UsuarioEvents> BuscarUsuarioEvent(Guid id)
        {
            var result = _context.Where(u => u.UsuarioModificadoId == id.ToString())
                .OrderByDescending(u => u.DataOcorrencia)
                .Take(20).ToList();

            var paged = new PagedEvent<UsuarioEvents>()
            {
                List = result
            };
            return paged;
        }
    }
}
