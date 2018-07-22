using System;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Enderecos.Entidades;

namespace Systrade.Dominio.Interfaces.Repository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Endereco AdicionarEndereco(Endereco obj);
        Endereco AtualizarEndereco(Endereco obj);
        void DeletarEndereco(Guid id);

        Endereco BuscarEnderecoPorId(Guid id);
        Paged<EnderecoDto> ObterTodosEnderecos(Guid id, string descricao, int pageSize, int pageNumber);
    }
}
