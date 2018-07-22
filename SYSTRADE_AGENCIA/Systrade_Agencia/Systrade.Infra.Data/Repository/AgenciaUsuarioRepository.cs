using Dapper;
using System;
using System.Data.Common;
using System.Linq;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Entidades;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Infra.Data.Context;

namespace Systrade.Infra.Data.Repository
{
    public class AgenciaUsuarioRepository : Repository<AgenciaUsuario>, IAgenciaUsuarioRepository
    {
        private DbConnection cn;

        public AgenciaUsuarioRepository(SystradeCadastroContext context)
           : base(context)
        {
            cn = _context.Database.Connection;
        }

        public AgenciaUsuario AdicionarAgenciaUsuario(AgenciaUsuario agenciausuario)
        {
            return Adicionar(agenciausuario);
        }

        public AgenciaUsuario AtualizarAgenciaUsuario(AgenciaUsuario agenciausuario)
        {
            return Atualizar(agenciausuario);
        }


        public AgenciaUsuario BuscarAgenciaUsuarioCpf(string cpf)
        {
            var cn = _context.Database.Connection;
            var sql = @"select * from AgenciaUsuario where cpf = @scpf";
            return cn.Query<AgenciaUsuario, AgenciaUsuarioDto, AgenciaUsuario>(sql, (a, ad) =>
            {
                a = new AgenciaUsuario(a.AgenciaId, a.UsuarioId, a.Nome, a.Sobrenome, ad.CPF, ad.Email, ad.Celular, ad.TelefoneFixo, a.Descricao);
                return a;
            }, new { scpf = cpf }, splitOn: "AgenciaId, EMAIL, CPF").FirstOrDefault();
        }

        public AgenciaUsuario BuscarAgenciaUsuarioEmail(string email)
        {
            var cn = _context.Database.Connection;
            var sql = @"select * from AgenciaUsuario where email = @semail";
            return cn.Query<AgenciaUsuario, AgenciaUsuarioDto, AgenciaUsuario>(sql, (a, ad) =>
            {
                a = new AgenciaUsuario(a.AgenciaId, a.UsuarioId, a.Nome, a.Sobrenome, ad.CPF, ad.Email, ad.Celular, ad.TelefoneFixo, a.Descricao);
                return a;
            }, new { semail = email }, splitOn: "AgenciaId, EMAIL, CPF").FirstOrDefault();
        }


        public AgenciaUsuario BuscarAgenciaUsuarioPorId(Guid id)
        {
            var cn = _context.Database.Connection;
            var sql = @"SELECT au.AgenciaId, au.UsuarioId, au.Nome, au.Sobrenome, au.CPF, au.Celular, au.TelefoneFixo,au.Email, " +
            "au.DataCadastro, au.Descricao, au.Status, ac.ClaimValue FROM AgenciaUsuario as au INNER JOIN AspNetUsers AS a ON " +
            "au.UsuarioId = a.Id INNER JOIN AspNetUserClaims AS ac ON a.Id = ac.UserId " +
            "WHERE UsuarioId = @sid ORDER BY au.Nome ";

            var result = cn.Query<AgenciaUsuario, AgenciaUsuarioDto, AgenciaUsuario>(sql, (a, ag) =>
            {
                a = new AgenciaUsuario(a.AgenciaId, a.UsuarioId, a.Nome, a.Sobrenome, ag.CPF, ag.Email, ag.Celular, ag.TelefoneFixo, a.Descricao);
                a.ClaimValue = ag.ClaimValue;
                return a;

            }, new { sid = id }, splitOn: "UsuarioId, CPF");
            return result.FirstOrDefault();

        }

        public AgenciaUsuario BuscarAgenciaUsuarioEmailParaEditar(string email, string id)
        {
            var cn = _context.Database.Connection;
            var sql = @"select * from AgenciaUsuario where email = @semail and UsuarioId <> @sid";
            return cn.Query<AgenciaUsuario>(sql, new { semail = email, sid = id }).FirstOrDefault();

        }

        public AgenciaUsuario DeletarAgenciaUsuario(AgenciaUsuario agenciausuario)
        {
            return Atualizar(agenciausuario);
        }

        public Paged<AgenciaUsuarioDto> ObterTodosAgenciaUsuario(Guid id, string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT au.AgenciaId, au.UsuarioId, au.Nome, au.Sobrenome, au.CPF, au.Email, au.Celular, au.TelefoneFixo, au.DataCadastro, au.Descricao, au.Status " +
            "FROM AgenciaUsuario AS au " +

            "WHERE au.AgenciaId  = @sid AND  au.Status <> 'false' AND " +
            "@Spesquisa IS NULL OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND  au.Nome LIKE @Spesquisa + '%' OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND au.Sobrenome LIKE @Spesquisa + '%' OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND au.CPF LIKE @Spesquisa + '%' OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND au.Descricao LIKE @Spesquisa + '%' " +
            "ORDER BY Nome ASC " +

            "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
            "FETCH NEXT " + pageSize + " ROWS ONLY " +
            " " +

            "SELECT COUNT(au.UsuarioId) FROM AgenciaUsuario AS au " +

            "WHERE au.AgenciaId  = @sid AND  au.Status <> 'false' AND " +
            "@Spesquisa IS NULL OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND au.Nome LIKE @Spesquisa + '%' OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND au.Sobrenome LIKE @Spesquisa + '%' OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND au.CPF LIKE @Spesquisa + '%' OR " +
            "au.AgenciaId = @sid AND au.Status <> 'false' AND au.Descricao LIKE @Spesquisa + '%' ";

            var multi = cn.QueryMultiple(sql, new { sid = id, Spesquisa = descricao });
            var agenciausuario = multi.Read<AgenciaUsuarioDto>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<AgenciaUsuarioDto>()
            {
                List = agenciausuario,
                Count = total
            };

            return pagedList;
        }

        public Paged<AgenciaUsuarioDto> ObterTodosUsuarioInativos(Guid id, string descricao, int pageSize, int pageNumber)
        {
            var sql = @"SELECT au.AgenciaId, au.UsuarioId, au.Nome, au.Sobrenome, au.CPF, au.Email, au.Celular, au.TelefoneFixo, au.DataCadastro, au.Descricao, au.Status " +
                      "FROM AgenciaUsuario AS au " +

                      "WHERE au.AgenciaId  = @sid AND  au.Status <> 'true' AND " +
                      "@Spesquisa IS NULL OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND  au.Nome LIKE @Spesquisa + '%' OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND au.Sobrenome LIKE @Spesquisa + '%' OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND au.CPF LIKE @Spesquisa + '%' OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND au.Descricao LIKE @Spesquisa + '%' " +
                      "ORDER BY Nome ASC " +

                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                      " " +

                      "SELECT COUNT(au.UsuarioId) FROM AgenciaUsuario AS au " +

                      "WHERE au.AgenciaId  = @sid AND  au.Status <> 'true' AND " +
                      "@Spesquisa IS NULL OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND au.Nome LIKE @Spesquisa + '%' OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND au.Sobrenome LIKE @Spesquisa + '%' OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND au.CPF LIKE @Spesquisa + '%' OR " +
                      "au.AgenciaId = @sid AND au.Status <> 'true' AND au.Descricao LIKE @Spesquisa + '%' ";

            var multi = cn.QueryMultiple(sql, new { sid = id, Spesquisa = descricao });
            var agenciausuario = multi.Read<AgenciaUsuarioDto>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<AgenciaUsuarioDto>()
            {
                List = agenciausuario,
                Count = total
            };

            return pagedList;
        }

        public AgenciaUsuario RestaurarAgenciaUsuario(AgenciaUsuario obj)
        {
            return AtualizarAgenciaUsuario(obj);
        }
    }
}
