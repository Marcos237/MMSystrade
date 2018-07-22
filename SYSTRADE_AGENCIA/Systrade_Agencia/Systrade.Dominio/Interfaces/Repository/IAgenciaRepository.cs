using System;
using Systrade.Dominio.Entidade;

namespace Systrade.Dominio.Interfaces.Repository
{
    public interface IAgenciaRepository : IRepository<Agencia>
    {
        Agencia AdicionarAgencia(Agencia obj);
        Agencia AtualizarAgencia(Agencia obj);
        Agencia BuscarAgenciaPorId(Guid id);
        Agencia BuscarAgenciaCnpj(string cnpj);
    }
}
