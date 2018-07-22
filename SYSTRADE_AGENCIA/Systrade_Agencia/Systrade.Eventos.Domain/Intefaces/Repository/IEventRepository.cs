using System;

namespace Systrade.Eventos.Domain.Intefaces.Repository
{
    public interface IEventRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
    }
}
