using Dapper;
using System;
using System.Data.Common;
using System.Linq;
using Systrade.Core.ValueObjects;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Infra.Data.Context;

namespace Systrade.Infra.Data.Repository
{
    public class AgenciaRepository : Repository<Agencia>, IAgenciaRepository
    {
        private DbConnection cn;

        public AgenciaRepository(SystradeCadastroContext context)
          : base(context)
        {
            cn = _context.Database.Connection;
        }

        public Agencia AdicionarAgencia(Agencia agencia)
        {
            return Adicionar(agencia);
        }

        public Agencia AtualizarAgencia(Agencia agencia)
        {
            return Atualizar(agencia);
        }

        public Agencia BuscarAgenciaPorId(Guid id)
        {
            var sql = @"SELECT ap.Id, ap.UserName, ag.UsuarioId, a.NomeFantasia, a.RazaoSocial, a.Cnpj, a.TelefoneFixo, a.AgenciaId" +
                      " FROM AspNetUsers ap Left JOIN AgenciaUsuario ag ON ap.Id = ag.UsuarioId " +
                      "INNER JOIN Agencia a ON ag.AgenciaId = a.AgenciaId " +
                      "WHERE UsuarioId = @sid";

            var result = cn.Query<Agencia, AgenciaDto, Agencia>(sql,
           (a, ad) =>
           {
               a = new Agencia(ad.AgenciaId, a.NomeFantasia, a.RazaoSocial, ad.CNPJ, ad.TelefoneFixo);
               return a;

           }, new { sid = id }, splitOn: "AgenciaId, CNPJ");

            var agencia = result.First();
            return agencia;
        }

        public Agencia BuscarAgenciaCnpj(string cnpj)
        {
            var sql = @"SELECT * FROM Agencia WHERE CNPJ = @scnpj";

            var result = cn.Query<Agencia, AgenciaDto, Agencia>(sql,
           (a, ad) =>
           {
               a = new Agencia(a.AgenciaId, a.NomeFantasia, a.RazaoSocial, ad.CNPJ, a.TelefoneFixo); return a;

           }, new { scnpj = cnpj }, splitOn: "AgenciaId, CNPJ");
            return result.FirstOrDefault();
        }
    }
}
