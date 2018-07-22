using Dapper;
using System;
using System.Data.Common;
using Systrade.Auditoria.Domain.DTO;
using Systrade.Auditoria.Entidades;
using Systrade.Auditoria.Infra.Data.Context;
using Systrade.Auditoria.Interfaces.Repository;

namespace Systrade.Auditoria.Infra.Data.Repository
{
    public class CadastroAuditoriaRepository : AuditoriaRepository<CadastroAuditoria>, ICadastroRepository
    {
        private DbConnection cn;

        public CadastroAuditoriaRepository(SystradeAuditoriaContext context)
          : base(context)
        {
            cn = _context.Database.Connection;
        }

        public CadastroAuditoria AdicionarCadastroEvent(CadastroAuditoria stored)
        {
            return Adicionar(stored);
        }

        public PagedDto<CadastroAuditoria> BuscarAgenciaUsuarioEvent(Guid id)
        {
            var sql = @"SELECT TOP 10 Id,UsuarioId, UserName, DataOcorrencia, Login, Permissao, Menssagem FROM  CadastroAuditoria " +
                      "WHERE UsuarioId = @sid " +
                      "ORDER By DataOcorrencia DESC ";

            var result = cn.Query<CadastroAuditoria>(sql, new { sid = id });

            var pagedList = new PagedDto<CadastroAuditoria>()
            {
                List = result
            };

            return pagedList;
        }
    }
}
