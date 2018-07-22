using System;

namespace Systrade.Dominio.Interfaces.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
