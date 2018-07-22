using System;
using System.Collections.Generic;
using Systrade.Clientes.Domain.DTO;
using Systrade.Clientes.Domain.Entidades;

namespace Systrade.Clientes.Domain.Intefaces.Services
{
    public interface IClienteService
    {
        Celula AdicionarCelula(Celula obj);
        Celula AtualizarCelula(Celula obj);
        Celula ExcluirCelula(Celula celula);
        Celula BuscarNomeCelula(string nomecelula);
        List<Celula> BuscarCelulaPorAgenciaId(Guid id);
        Celula ObterCelulaPorId(Guid id);
        PagedClientes<Celula> ObterTodosCelulaInativos(Guid id, string descricao, int pageSize, int pageNumber);
        Celula RestaurarCelula(Celula celula);
    }
}
