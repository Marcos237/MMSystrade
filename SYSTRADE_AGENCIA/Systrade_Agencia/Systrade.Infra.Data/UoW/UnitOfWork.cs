using System;
using Systrade.Dominio.Interfaces.Uow;
using Systrade.Infra.Data.Context;

namespace Systrade.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private  SystradeCadastroContext _context;


        public UnitOfWork(SystradeCadastroContext context)
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