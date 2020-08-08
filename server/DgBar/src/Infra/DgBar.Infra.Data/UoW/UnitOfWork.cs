using DgBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool Commit()
        {
            //implementar savechanges
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
