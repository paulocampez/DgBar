using DgBar.Domain.Interfaces;
using DgBar.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DgBarContext _context;

        public UnitOfWork(DgBarContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
