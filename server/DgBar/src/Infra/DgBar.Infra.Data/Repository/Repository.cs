using DgBar.Domain.Interfaces;
using DgBar.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DgBarContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(DgBarContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
