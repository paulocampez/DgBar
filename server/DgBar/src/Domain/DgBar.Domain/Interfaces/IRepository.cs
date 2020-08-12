using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DgBar.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();

        void Delete(TEntity obj);
    }
}
