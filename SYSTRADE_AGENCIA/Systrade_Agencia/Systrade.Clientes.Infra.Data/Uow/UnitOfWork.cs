using Systrade.Clientes.Infra.Data.Context;
using Systrade.Clientes.Infra.Data.Interfaces;

namespace Systrade.Clientes.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private SystradeClientesContext _context;


        public UnitOfWork(SystradeClientesContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}