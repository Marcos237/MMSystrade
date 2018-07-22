using System;
using System.Collections.Generic;
using Systrade.Clientes.Domain.DTO;
using Systrade.Clientes.Domain.Entidades;

namespace Systrade.Clientes.Domain.Intefaces.Repository
{
    public interface ICelulaRepository : IRepository<Celula>
    {
        Celula AdicionarCelula(Celula obj);
        Celula AtualizarCelula(Celula obj);
        Celula BuscarNomeCelula(string nomeCelula);
        List<Celula> BuscarCelulaPorAgenciaId(Guid id);
        Celula ObterCelulaPorId(Guid id);
        PagedClientes<Celula> ObterTodosCelulaInativos(Guid id, string descricao, int pageSize, int pageNumber);
    }
}
