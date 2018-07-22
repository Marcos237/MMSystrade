using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Systrade.Clientes.Domain.DTO;
using Systrade.Clientes.Domain.Entidades;
using Systrade.Clientes.Domain.Intefaces.Repository;
using Systrade.Clientes.Infra.Data.Context;

namespace Systrade.Clientes.Infra.Data.Repository
{
    public class CelulaRepository : Repository<Celula>, ICelulaRepository
    {
        private DbConnection cn;

        public CelulaRepository(SystradeClientesContext context)
          : base(context)
        {
            cn = _context.Database.Connection;
        }

        public Celula AdicionarCelula(Celula obj)
        {
            return Adicionar(obj);
        }

        public Celula AtualizarCelula(Celula obj)
        {
            return Atualizar(obj);
        }

        public List<Celula> BuscarCelulaPorAgenciaId(Guid id)
        {
            var sql = @"SELECT * FROM Celula WHERE AgenciaId = @sid AND Status ='True' ORDER BY NomeCelula ASC ";
            var result = cn.Query<Celula>(sql, new { sid = id }).ToList();
            return result;
        }

        public Celula BuscarNomeCelula(string nomeCelula)
        {
            var sql = @"SELECT NomeCelula FROM Celula WHERE NomeCelula = @snomecelula ";
            var result = cn.Query<Celula>(sql, new { snomecelula = nomeCelula });
            return result.FirstOrDefault();
        }

        public Celula ObterCelulaPorId(Guid id)
        {
            var sql = @"SELECT * FROM Celula WHERE CelulaId = @sid ";
            var result = cn.Query<Celula>(sql, new { sid = id });
            return result.FirstOrDefault();
        }

        public PagedClientes<Celula> ObterTodosCelulaInativos(Guid id, string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT c.AgenciaId, c.CelulaId, c.NomeCelula, c.DataCadastro FROM Celula AS c " +
            "WHERE c.AgenciaId = @sid AND c.Status = 'false' AND @Spesquisa IS NULL OR " +
            "c.AgenciaId = @sid AND c.Status = 'false' AND c.NomeCelula LIKE @Spesquisa + '%' OR " +
            "c.AgenciaId = @sid AND c.Status = 'false' AND c.DataCadastro LIKE @Spesquisa + '%' " +
            "ORDER BY c.NomeCelula ASC " +

            "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
            "FETCH NEXT " + pageSize + " ROWS ONLY " +
            " " +

            "SELECT COUNT(c.AgenciaId) FROM Celula AS c " +
            "WHERE c.AgenciaId  = @sid AND  c.Status = 'false' AND @Spesquisa IS NULL OR " +
            "c.AgenciaId  = @sid AND c.Status = 'false' AND c.NomeCelula LIKE @Spesquisa + '%' OR " +
            "c.AgenciaId  = @sid AND c.Status = 'false' AND c.DataCadastro LIKE @Spesquisa + '%' ";

            var multi = cn.QueryMultiple(sql, new { sid = id, Spesquisa = descricao });
            var celula = multi.Read<Celula>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new PagedClientes<Celula>()
            {
                List = celula,
                Count = total
            };

            return pagedList;



        }
    }
}
