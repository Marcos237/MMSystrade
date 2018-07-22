using System;

namespace Systrade.Clientes.Infra.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
