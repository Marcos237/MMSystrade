using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidades;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Infra.Data.Context;

namespace Systrade.Infra.Data.Repository
{
    public class RegistroUsuarioRepository : Repository<RegistroUsuario>, IRegistroUsuarioRepository
    {
        private DbConnection cn;

        public RegistroUsuarioRepository(SystradeCadastroContext context)
           : base(context)
        {
            cn = _context.Database.Connection;
        }

        public RegistroUsuario AdicionarRegistro(RegistroUsuario registro)
        {
            return Adicionar(registro);
        }

        public void DeletarRegistroUsuario(Guid id)
        {
            var _registro = BuscarRegistros(id);
            foreach (var itens in _registro)
            {
                Remover(itens.RegistroUsuarioId);
            }
        }

        public RegistroUsuario ObterRegistroUsuarioPorId(Guid id)
        {
            var cn = _context.Database.Connection;
            var sql = @"SELECT * FROM RegistroUsuario WHERE UsuarioId = @sid";
            return  cn.Query<RegistroUsuario>(sql, new { sid = id }).FirstOrDefault();

        }

        public Paged<RegistroUsuario> ObterTodosUsers(Guid id, string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT a.AgenciaId, ap.Id, ap.UserName, r.IP, r.Registro, r.DataCadastro FROM Agencia AS a INNER JOIN " +
           "AgenciaUsuario AS au ON a.AgenciaId = au.AgenciaId  " +
           "INNER JOIN AspNetUsers AS ap ON au.UsuarioId = ap.Id " +
           "INNER JOIN RegistroUsuario AS r ON ap.Id = r.UsuarioId " +
           "WHERE a.AgenciaId  = @sid  AND @Spesquisa IS NULL OR " +
           "a.AgenciaId = @sid  AND  ap.UserName LIKE @Spesquisa + '%'" +
           "ORDER BY r.DataCadastro DESC " +

           "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
           "FETCH NEXT " + pageSize + " ROWS ONLY " +
           " " +

           "SELECT COUNT(a.AgenciaId) FROM Agencia AS a INNER JOIN " +
           "AgenciaUsuario AS au ON a.AgenciaId = au.AgenciaId  " +
           "INNER JOIN AspNetUsers AS ap ON au.UsuarioId = ap.Id " +
           "INNER JOIN RegistroUsuario AS r ON ap.Id = r.UsuarioId " +
           "WHERE a.AgenciaId  = @sid  AND @Spesquisa IS NULL OR " +
           "a.AgenciaId = @sid  AND  ap.UserName LIKE @Spesquisa + '%'";

            var multi = cn.QueryMultiple(sql, new { sid = id, Spesquisa = descricao });
            var user = multi.Read<RegistroUsuario>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<RegistroUsuario>()
            {
                List = user,
                Count = total
            };

            return pagedList;
        }

        public List<RegistroUsuario> BuscarRegistros(Guid id)
        {
            var sql = @"SELECT * FROM RegistroUsuario WHERE UsuarioId = @sid";
            return  cn.Query<RegistroUsuario>(sql, new { sid = id }).ToList();

        }
    }
}
