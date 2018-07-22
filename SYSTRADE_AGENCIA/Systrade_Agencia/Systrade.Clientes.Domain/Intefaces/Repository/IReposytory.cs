using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Systrade.Clientes.Domain.Intefaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
        int SaveChanges();
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}