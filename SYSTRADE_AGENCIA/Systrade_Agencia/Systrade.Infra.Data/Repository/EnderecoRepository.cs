using Dapper;
using System;
using System.Data.Common;
using System.Linq;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Infra.Data.Context;

namespace Systrade.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        private DbConnection cn;

        public EnderecoRepository(SystradeCadastroContext context)
           : base(context)
        {
            cn = _context.Database.Connection;
        }

        public Endereco AdicionarEndereco(Endereco endereco)
        {
            return Adicionar(endereco);
        }

        public Endereco AtualizarEndereco(Endereco endereco)
        {
            return Atualizar(endereco);
        }

        public Endereco BuscarEnderecoPorId(Guid id)
        {
            var sql = "select * from Enderecos where EnderecoId = @sid";
            var result = cn.Query<Endereco, EnderecoDto, Endereco>(sql, (e, ed) =>
            {
                e = new Endereco(e.EnderecoId, e.AgenciaId, e.Descricao, e.Logradouro, e.Complemento, e.Numero, ed.Cep, e.Cidade, e.Estado);
                return e;
            }, new { sid = id }, splitOn: "EnderecoId, CEP");
            return result.FirstOrDefault();
        }

        public Paged<EnderecoDto> ObterTodosEnderecos(Guid Id, string pesquisa, int pageSize, int pageNumber)
        {
            var sql = @"SELECT  a.AgenciaId, e.EnderecoId, e.Logradouro, e.Complemento, e.Numero, e.Cidade, e.Estado, e.cep, e.descricao " +
            "FROM Agencia AS a INNER JOIN Enderecos AS e  ON  a.AgenciaId = e.AgenciaId " +

            "WHERE a.AgenciaId  = @sid AND @Spesquisa IS NULL OR " +
            "a.AgenciaId  = @sid AND e.Descricao LIKE @Spesquisa + '%' OR " +
            "a.AgenciaId  = @sid AND e.Logradouro LIKE @Spesquisa + '%' OR " +
            "a.AgenciaId  = @sid AND e.Estado LIKE @Spesquisa + '%' OR " +
            "a.AgenciaId  = @sid AND e.Cidade LIKE @Spesquisa + '%' " +
            "ORDER BY Logradouro ASC " +

            "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
            "FETCH NEXT " + pageSize + " ROWS ONLY " +
            " " +

            "SELECT COUNT(e.EnderecoId) FROM Agencia AS a INNER JOIN Enderecos AS e  ON  a.AgenciaId = e.AgenciaId " +

            "WHERE a.AgenciaId  = @sid AND @Spesquisa IS NULL OR " +
            "a.AgenciaId  = @sid AND e.Descricao LIKE @Spesquisa + '%' OR " +
            "a.AgenciaId  = @sid AND e.Logradouro LIKE @Spesquisa + '%' OR " +
            "a.AgenciaId  = @sid AND e.Estado LIKE @Spesquisa + '%' OR " +
            "a.AgenciaId  = @sid AND e.Cidade LIKE @Spesquisa + '%' ";


            var multi = cn.QueryMultiple(sql, new { sid = Id, Spesquisa = pesquisa });
            var enderecos = multi.Read<EnderecoDto>();
            var total = multi.Read<int>().FirstOrDefault();

            

            var pagedList = new Paged<EnderecoDto>()
            {
                List = enderecos,
                Count = total
            };

            return pagedList;
        }

        public void DeletarEndereco(Guid id)
        {
            Remover(id);
        }
    }
}
