using System;
using System.Data.Entity;
using Systrade.Auditoria.Infra.Data.Context;
using Systrade.Auditoria.Interfaces.Repository;

namespace Systrade.Auditoria.Infra.Data.Repository
{
    public class AuditoriaRepository<TEntity> : IAuditoriaRepository<TEntity> where TEntity : class
    {
        protected SystradeAuditoriaContext _context;
        protected DbSet<TEntity> DbSet;

        public AuditoriaRepository(SystradeAuditoriaContext contex)
        {
            _context = contex;
            DbSet = _context.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            _context.SaveChanges();
            return objreturn;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
