using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Systrade.Dominio.Entidade.Cadastro;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Infra.Data.Context;

namespace Systrade.Infra.Data.Repository
{
    public class ClaimRepository : Repository<Claims>, IClaimsRepository
    {
        private DbConnection cn;

        public ClaimRepository(SystradeCadastroContext context)
        : base(context)
        {
            cn = _context.Database.Connection;
        }

        public List<Claims> BuscarClaims()
        {
            var sql = "SELECT * FROM AspNetClaims ORDER BY ClaimValue ASC";
            return cn.Query<Claims>(sql, new { }).ToList();
        }

        public Claims BuscarClaimsPorId(Guid id)
        {
            var sql = "SELECT * FROM AspNetUserClaims WHERE UserId = @sid";
            return cn.Query<Claims>(sql, new { sid = id }).FirstOrDefault();
        }
    }
}
